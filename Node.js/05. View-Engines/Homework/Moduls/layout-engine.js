var jade = require('jade');
var fs = require('fs');
var path = require('path');

function render(pathOfFile, content, cb) {

    fs.readFile(pathOfFile, 'utf-8', function (err, template) {
        if (err) {
            return cb(err.toString());
        }

        var template = jade.compile(template, {
            filename: pathOfFile
        } );

        var output = template(content);

        return cb(output);
    });
}

module.exports.Render = render;

