import axios from "axios";
import { useState } from "react";
import { useEffect } from "react";

const BACKEND_URL = "http://localhost:3000"

function App() {
  const [users, setUsers] = useState([]);

  const fetchData = async () => {
    const users = await axios(`${BACKEND_URL}/users`);
    setUsers(users.data);
  };

  useEffect(() => {
    fetchData()
  }, []);


  const createUser = async () => {
    const email = prompt("Enter email")
    const username = prompt("Enter username")
    const mobile = prompt("Enter mobile")

    const obj = {email, username, mobile}
    
    await fetch(`${BACKEND_URL}/users`, {
        body: JSON.stringify(obj),
        method:"POST",
        headers: {
            'Content-Type': "application/json"
        }
    })

    await fetchData()

}

  return (
    <>
      <div class="header">
        <h2>Users</h2>
        <button onClick={createUser}>Create User</button>
      </div>

      <div class="users">
        {console.log(users) 
        }
        {users.map((user) => (
          <div class="user">
            <h3>{user.username}</h3>
            <p>{user.mobile}</p>
            <p>{user.email}</p>
          </div>
        ))}
      </div>
    </>
  );
}

export default App;
