"use strict";

var User = require('mongoose').model('User');
var Message = require('mongoose').model('Message');

var registerUser = function(user,func) {
    if (!user || !user.user || !user.pass) {
        if(!func)
        {
            return;
        }

        func("invalid user");
        return;
    }

    var newUser = new User(user);
    newUser.save(function (err, succ) {
        if(!func)
        {
            return;
        }

        if (err) {
            func(err);

            return;
        }

        func(undefined,succ);
    });
};

var sendMessage = function(message,func){
    if (!message || !message.from || !message.to || !message.text) {
        if(!func)
        {
            return;
        }

        func('Invalid message');
        return;
    }

    var newMessage = new Message(message);
    newMessage.save(function (err, succ) {
        if (err) {
            if(!func)
            {
                return;
            }

            func(err);

            return;
        }

        if(!func)
        {
            return;
        }

        func(undefined,succ);
    });
}

var getMessages = function(users,func){
    Message.find([{from: users.with, to: users.and},
        {from: users.and, to: users.with}])
        .exec(function (err, succ) {
            if (err) {
                if(!func)
                {
                    return;
                }

                func(err);

                return;
            }

            if(!func)
            {
                return;
            }

            func(undefined,succ);
        });
}

module.exports.registerUser  = registerUser;
module.exports.sendMessage = sendMessage;
module.exports.getMessages = getMessages;
