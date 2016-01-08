var mongoose = require('mongoose');

module.exports.init = function () {
    var messageSchema = mongoose.Schema({
        from: {type: String, required: true},
        to: {type: String, required: true},
        text: {type: String, required: true}
    });

    mongoose.model('Message', messageSchema);
}
