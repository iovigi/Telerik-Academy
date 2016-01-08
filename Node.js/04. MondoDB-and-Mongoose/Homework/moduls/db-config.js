var mongoose = require('mongoose');
var  User = require('./Models/user');
var  Message = require('./Models/message');

module.exports.init = function(func) {
    mongoose.connect('mongodb://localhost:27017/Chat');
    var db = mongoose.connection;

    db.once('open', function(err) {
        if (err) {
            if(func){
                func(err);
            }

            return;
        }

        if(func){
            func(undefined,"Success");
        }
    });

    db.on('error', function(err){
        func(err);
    });

    User.init();
    Message.init();
};
