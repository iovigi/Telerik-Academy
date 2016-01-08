var mongoose = require('mongoose');

module.exports.init = function () {
    var userSchema = mongoose.Schema({
        user: {type: String, required: true},
        pass: {type: String, required: true}
    });

    mongoose.model('User', userSchema);
}
