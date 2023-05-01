import Image from 'next/image'
import AddNewTodo from './create-new-todo'
import TodoList from './todo-list'

export default function Home() {
  return (
    <div>
      <article>
        <AddNewTodo/>
      </article>
        <TodoList/>
    </div>
  )
}
