var encryption = require('../utilities/encryption'),
    auth = require('../../config/auth'),
    users = require('../data/database'),
    express = require('express'),
    router = express.Router(),
    User= require('../models/User');

var CONTROLLER_NAME = 'users';

module.exports = function (app) {
  app.use('/', router);
};

router.get('/logout', auth.isAuthenticated, auth.logout);

router.get('/login', function (req, res, next) {
  res.render(CONTROLLER_NAME + '/login', {
    title: 'Login',
    authorised : req.isAuthenticated()
  });
});

router.post('/login', auth.login);

router.get('/register', function (req, res, next) {
  res.render(CONTROLLER_NAME + '/register', {
    title: 'Register',
    authorised : req.isAuthenticated()
  });
});

router.post('/register', function (req, res, next) {
  var newUserData = req.body;

  if (newUserData.password != newUserData.confirmPassword) {
    req.session.error = 'Passwords do not match!';
    res.redirect('/register');
  }
  else {
    var user = new User();
    user.salt = encryption.generateSalt();
    user.hashPass = encryption.generateHashedPassword(user.salt, newUserData.password);
    user.username = newUserData.username;
    console.log(user.username);
    users.addUser(user);

    req.logIn(user, function(err) {
      if (err) return next(err);
      res.redirect('/');
    });
  }
});
