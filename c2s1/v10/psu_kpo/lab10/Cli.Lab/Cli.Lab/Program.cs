var stream = File.ReadAllText("sample.txt").Split("\n").Where(x => x != String.Empty);
File.WriteAllLines("output.txt", stream);