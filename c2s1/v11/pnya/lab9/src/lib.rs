use std::io;
use winapi;
use winapi::um::winuser::SetWindowsHookExA;
use winapi::um::winuser::UnhookWindowsHookEx;
use winapi::um::winuser::{HC_ACTION, WH_KEYBOARD_LL};

pub fn get_key_down() {
    let hook_id =
        unsafe { SetWindowsHookExA(WH_KEYBOARD_LL, Some(hook_callback), std::ptr::null_mut(), 0) };

    println!("hook_id: {:?}", hook_id);

    println!("Type \"exit\" to exit");
    loop {
        let mut command = String::new();

        io::stdin()
            .read_line(&mut command)
            .expect("Failed to read line");

        match command.trim() {
            "exit" => break,
            _ => println!("Type \"exit\" to exit"),
        };
    }

    unsafe {
        UnhookWindowsHookEx(hook_id);
    }
}

extern "system" fn hook_callback(code: i32, w_param: usize, l_param: isize) -> isize {
    println!("hook_callback {}, {}, {}", code, w_param, l_param);
    if code == HC_ACTION {
        println!("Activate");
    }
    0
}
