fn sha1(message: &[u8]) -> [u8; 20] {
    // Начальное значение A, B, C, D, E в соответствии со стандартом
    let mut h0: u32 = 0x67452301;
    let mut h1: u32 = 0xEFCDAB89;
    let mut h2: u32 = 0x98BADCFE;
    let mut h3: u32 = 0x10325476;
    let mut h4: u32 = 0xC3D2E1F0;

    // Дополнение сообщения
    let mut padded = message.to_vec();
    padded.push(0x80); // добавляем бит "1" в конец сообщения
    while padded.len() % 64 != 56 {
        // добавляем нули до тех пор, пока длина сообщения не станет кратной 512 битам
        padded.push(0);
    }
    let len_bits = (message.len() as u64) * 8;
    padded.extend_from_slice(&len_bits.to_be_bytes()); // добавляем длину сообщения в битах в конец сообщения

    // Обработка сообщения
    for chunk in padded.chunks(64) {
        let mut words = [0u32; 80];

        // Разбиение блока на 16 32-битных слов
        for i in 0..16 {
            let j = i * 4;
            words[i] = ((chunk[j] as u32) << 24)
                | ((chunk[j + 1] as u32) << 16)
                | ((chunk[j + 2] as u32) << 8)
                | (chunk[j + 3] as u32);
        }

        // Расширение блока до 80 слов
        for i in 16..80 {
            let word = words[i - 3] ^ words[i - 8] ^ words[i - 14] ^ words[i - 16];
            words[i] = word.rotate_left(1);
        }

        // Инициализация переменных
        let mut a = h0;
        let mut b = h1;
        let mut c = h2;
        let mut d = h3;
        let mut e = h4;

        // Вычисление
        for i in 0..80 {
            let f;
            let k;
            if i < 20 {
                f = (b & c) | ((!b) & d);
                k = 0x5A827999;
            } else if i < 40 {
                f = b ^ c ^ d;
                k = 0x6ED9EBA1;
            } else if i < 60 {
                f = (b & c) | (b & d) | (c & d);
                k = 0x8F1BBCDC;
            } else {
                f = b ^ c ^ d;
                k = 0xCA62C1D6;
            }
            let temp = a
                .rotate_left(5)
                .wrapping_add(f)
                .wrapping_add(e)
                .wrapping_add(k)
                .wrapping_add(words[i]);
            e = d;
            d = c;
            c = b.rotate_left(30);
            b = a;
            a = temp;
        }

        // Обновление значений хэш-функции
        h0 = h0.wrapping_add(a);
        h1 = h1.wrapping_add(b);
        h2 = h2.wrapping_add(c);
        h3 = h3.wrapping_add(d);
        h4 = h4.wrapping_add(e);
    }

    // Формирование итогового хэша
    let mut hash = [0u8; 20];
    hash[..4].copy_from_slice(&h0.to_be_bytes());
    hash[4..8].copy_from_slice(&h1.to_be_bytes());
    hash[8..12].copy_from_slice(&h2.to_be_bytes());
    hash[12..16].copy_from_slice(&h3.to_be_bytes());
    hash[16..].copy_from_slice(&h4.to_be_bytes());
    hash
}

fn main() {
    let s = String::from("Hello World");
    let hashed = sha1(s.as_bytes());
    for n in hashed {
        print!("{:o}", n);
    }
}
