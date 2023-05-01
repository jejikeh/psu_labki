"use client";

import { useRouter } from "next/navigation";

async function update(id, isDone, refresh) {
    await fetch("http://127.0.0.1:3000/api/todos/", {
        method: "PUT",
        mode: "cors",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
          },
        cache: "no-store",
        body: JSON.stringify({id, isDone})
    });

    refresh();
}

async function deleteTodo(id, refresh) {
    await fetch(`http://127.0.0.1:3000/api/todos/${id}`, {
        method: "DELETE",
        mode: "cors",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
          },
        cache: "no-store",
    });

    refresh();
}

export default function Todo({ todo }) {
    let endDate = "now"
    let dateStyle = { background: "#e84a4a" }

    if (todo.isDone) {
        dateStyle = { background: "#55bd71" }
        endDate = todo.endDate;
    }

    const router = useRouter();

    return (
        <article>
            <h1>
                {todo.title}
            </h1>
                <mark style={dateStyle}>
                    {todo.startDate} | {endDate}
                </mark>
                <aside>
                <input type="checkbox" id="checkbox" style={{ marginLeft: "10px"}} onChange={(e) => update(todo.id, e.target.checked, router.refresh)} checked={todo.isDone}/>
                <button style={{ marginLeft: "5px", background: "#e84a4a"}} onClick={() => deleteTodo(todo.id, router.refresh)}>Delete</button>
                </aside>
        </article>
    )
}