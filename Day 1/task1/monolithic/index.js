const mongoose = require("mongoose");
const express = require("express");
const { GetAllUsers, CreateUser } = require("./Controllers/UserController");

const app = express();

app.use(express.json());
app.set("view engine", "ejs");

app.post("/users", async (req, res) => {
  try {
    console.log(req.body);
    
    const { email, username, mobile } = req.body;

    const users = await CreateUser(username, email, mobile);

    res.json("successfully createde user");
  } catch (error) {
    res.json(error.message);
  }
});

app.get("*", async (req, res) => {
  const users = await GetAllUsers();
    users.reverse()
  res.render("index", {users});
});

const PORT = 3000;
mongoose
  .connect("mongodb://localhost/migrationdb")
  .then(() => {
    app.listen(PORT, () => {
      console.log(`App is listening on port ${PORT}`);
    });
  })
  .catch(() => {});
