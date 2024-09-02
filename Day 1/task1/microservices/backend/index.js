const mongoose = require("mongoose");
const express = require("express");
const { GetAllUsers, CreateUser } = require("./Controllers/UserController");
const cors = require("cors")

const app = express();

app.use(express.json());

app.use(cors())

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
  users.reverse();
  res.json(users);
});

const PORT = 3000;
const MONGODB_URL = process.env.MONGODB_URI || "mongodb://localhost/migrationdb"
mongoose
  .connect(MONGODB_URL)
  .then(() => {
    app.listen(PORT, () => {
      console.log(`App is listening on port ${PORT}`);
    });
  })
  .catch(() => {});
