var    encryption = require('../utilities/encryption');

var User = function() {
  this.username = "";
  this.salt="";
  this.hashPass = "";
};

User.prototype.authenticate = function(password) {
  var newHash = encryption.generateHashedPassword(this.salt, password);
  console.log(newHash);
  console.log(this.hashPass);

  if (newHash === this.hashPass) {
    return true;
  }
  else {
    return false;
  }
};

module.exports = User;


