import Todo from "./todo";

const getTodos = async () => {
    let todos = await fetch("http://localhost:3000/api/todos/", {
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
          },
        cache: "no-store",
    });
    return todos.json();
}

export default async function TodoList() {
    const todos  = await getTodos();
    console.log(todos);

    return (
        <div>
            <ul>
                {todos.map((t) => {
                    return (
                        <ol key={t.id}>
                            <Todo todo={t}/>
                        </ol>
                    )
                })}
            </ul>
        </div>
    )
}