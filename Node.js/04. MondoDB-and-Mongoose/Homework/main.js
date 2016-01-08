var db  = require('./moduls/db-config');

var log = function(err,succ)
{
    if(err){
        console.log(err);
    }

    if(succ){
        console.log(succ);
    }
};

db.init(log);

var chatDb = require('./moduls/chat-db');

chatDb.registerUser({user: 'DonchoMinkov', pass: '123456q'},log);
//inserts a new message record into the DB
//the message has two references to users (from and to)
chatDb.sendMessage({
    from: 'DonchoMinkov',
    to: 'NikolayKostov',
    text: 'Hey, Niki!'
},log);
//returns an array with all messages between two users
chatDb.getMessages({
    with: 'DonchoMinkov',
    and: 'NikolayKostov'
},log);