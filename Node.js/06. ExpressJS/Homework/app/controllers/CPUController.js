
var  auth = require('../../config/auth'),
  cpus = require('../data/database'),
  express = require('express'),
  router = express.Router(),
  fs = require('fs'),
  CPU= require('../models/CPU');

module.exports = function (app) {
  app.use('/', router);
};

router.get('/list', function (req, res, next) {
  console.log(cpus.listCpus());
  res.render('list', {
    title: 'List',
    cpus:cpus.listCpus(),
    authorised : req.isAuthenticated()
  });
});

router.get('/detail/:id', function (req, res, next) {
  var cpu = cpus.getCpuById(req.params.id);
  console.log(cpu);

  res.render('detail', {
    title: 'detail',
    cpu:cpu,
    authorised : req.isAuthenticated()
  });
});

router.get('/add', function (req, res, next) {
  if(!req.isAuthenticated())
  {
    res.redirect('/login');
  }

  res.render('addCpu', {
    title: 'Add CPU',
    authorised : req.isAuthenticated()
  });
});

router.post('/add', function (req, res, next) {
  if(!req.isAuthenticated())
  {
    res.redirect('/login');
  }

  var fstream;
  req.pipe(req.busboy);

  var cpu = {};

  req.busboy.on('file', function (fieldname, file, filename) {
    fstream = fs.createWriteStream(__dirname + '/../../public/img/' + filename);
    file.pipe(fstream);
    cpu.imgLink = '/img/' + filename;
  });

  req.busboy.on('field', function(fieldname, val, fieldnameTruncated, valTruncated) {
    cpu[fieldname] = val;
  });

  req.busboy.on('finish', function() {
    console.log(cpu);
    cpus.addCpu(cpu);
    res.redirect('/list');
  });
});
