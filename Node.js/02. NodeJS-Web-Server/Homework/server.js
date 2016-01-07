var http = require('http');
var fs = require('fs-extra');
var url = require('url');
var frd = require('formidable');
var uuid = require('node-uuid');

var server = http.createServer(function (req, resp) {

    var queryData = url.parse(req.url, true).query;

    var urlAddr = url.parse(req.url);
    if(urlAddr.pathname == "/upload")
    {
        resp.writeHead(200, { 'content-type': 'text/html' });

        if(req.method == "GET")
        {
            resp.write("<form method='post' enctype='multipart/form-data'>");
            resp.write("<input type='file' name='upload' multiple='multiple'/>");
            resp.write("<input type='submit' />");
            resp.write("</form>")
            resp.end();
        }
        else if(req.method == "POST")
        {
            var form = new frd.IncomingForm();

            // parse the form
            form.parse(req, function (error, fields, files) {

            });

            // on formidable request end
            form.on('end', function (fields, files) {
                console.log(this);
                var fileName = this.openedFiles[0].name;

                var extension = fileName.substring(fileName.lastIndexOf('.'));

                var guid = uuid.v1();

                var path = this.openedFiles[0].path;
                var name = guid + extension;
                console.log(name);

                console.log(this);
                fs.copy(path, './files/'+name, function (error) {
                    if (error) {
                        resp.write("ERROR");
                    } else {
                        resp.write("SUCCESS");
                    }

                    resp.end();
                });
            });
        }

        return;
    }

    if(urlAddr.pathname.indexOf("files") > -1)
    {
        resp.writeHead(200,
            {
                'Content-Disposition': ('attachment; filename='+urlAddr.pathname.substring(urlAddr.pathname.indexOf("files"))+';')
            });
        var readStream = fs.createReadStream("./"+urlAddr.pathname);
        readStream.pipe(resp);

        readStream.on("finish",function()
        {
            resp.end();

            return;
        });
    }
    else {
        resp.writeHead(200, { 'content-type': 'text/html' });

        var files = [];
        fs.readdir("./files", function(err, items) {
            for (var i=0; i<items.length; i++) {
                var file = "./files/" + items[i];

                resp.write("<a href='"+file+"'>"+file+"</a></br>");
            }

            resp.write("<a href='/upload'>Upload</a></br>");
            resp.end();
        });
    }
});

server.listen(5050);