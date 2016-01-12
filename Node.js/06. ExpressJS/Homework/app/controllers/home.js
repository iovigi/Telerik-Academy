var express = require('express'),
  router = express.Router(),
  auth = require('../../config/auth')
  Article = require('../models/cpu');

module.exports = function (app) {
  app.use('/', router);
};

router.get('/', function (req, res, next) {
  console.log(req.isAuthenticated());
    res.render('index', {
      title: 'CPU Page',
      authorised : req.isAuthenticated()
    });
});
