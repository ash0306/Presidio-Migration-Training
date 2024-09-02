const User = require("../Models/User");

const GetAllUsers = async () => {
  const users = await User.find({}, "username email mobile");
  return users;
};

const CreateUser = async (username, email, mobile) => {
  const user = new User({
    username,
    email,
    mobile,
  });

  await user.save();
};

module.exports = { GetAllUsers, CreateUser };
