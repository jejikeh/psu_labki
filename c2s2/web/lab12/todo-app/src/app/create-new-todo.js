"use client";

import { useRouter } from "next/navigation";
import { useState } from "react";

async function add(title, refresh) {
    await fetch("http://127.0.0.1:3000/api/todos/", {
        method: "POST",
        mode: "cors",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
          },
        cache: "no-store",
        body: JSON.stringify({title})
    });

    refresh();
}

export default function AddNewTodo() {
    const router = useRouter();
    let [title, setTitle] = useState("");
    return (
        <div>
            <p>
                <label>Input your Todo: </label>
                <input type="text" name="first_name" onChange={(e) => setTitle(e.target.value)} value={title}/>
            </p> 
            <button onClick={() => add(title, router.refresh)}>Add</button>
        </div>
        )
}