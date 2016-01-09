var http = require('http');
var url = require('url');
var LayoutEngine = require("./Moduls/layout-engine");
var Data = require("./Data/data");

var server = http.createServer(function (req, resp) {
    var urlAddr = url.parse(req.url);

	var content = {
		navItems :["home", "SmartPhones", "Tablets", "Wearables"]
	};

    if(urlAddr.pathname == "/home"){
		content.titlePage = "Home";

		var wrap = { content : content };
		LayoutEngine.Render("./Layouts-Jade/home.jade",wrap, function(cont)
		{
			View(resp,cont);
		});
	}
	else if(urlAddr.pathname == "/SmartPhones"){
		content.titlePage = "Smart Phones";
		content.products = Data.Phones;

		var wrap = { content : content };
		LayoutEngine.Render("./Layouts-Jade/products.jade",wrap, function(cont)
		{
			View(resp,cont);
		});
	}
	else if(urlAddr.pathname == "/Tablets"){
		content.titlePage = "Tablets";
		content.products = Data.Tablets;

		var wrap = { content : content };
		LayoutEngine.Render("./Layouts-Jade/products.jade",wrap, function(cont)
		{
			View(resp,cont);
		});
	}
	else if(urlAddr.pathname == "/Wearables"){
		content.titlePage = "Wearables";
		content.products = Data.Wearables;

		var wrap = { content : content };
		LayoutEngine.Render("./Layouts-Jade/products.jade",wrap, function(cont)
		{
			View(resp,cont);
		});
	}
	else { //404
		resp.writeHead(404);
		resp.write("Page Not Found");

		resp.end();
	}
});

function View(resp, content) {
	resp.writeHead(200, {
		'Content-Type': 'text/html'
	});

	resp.write(content);

	resp.end();
}

server.listen(5050);