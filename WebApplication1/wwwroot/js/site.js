// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function goods() {
	let goods = [];
	this.S = async function (url, parms, succ, err) {

	//	Connector.Ajax(JSON.stringify({ id: 1461, name: "3ss====>" }), "goods", "", "", "PUT")
	}
	this.D = function () {
		//	Connector.Ajax(JSON.stringify({ id: 1461, name: "3ss====>" }), "goods", "", "", "PUT")
	}
	this.IU = function () {
		//	Connector.Ajax(JSON.stringify({ id: 1461, name: "3ss====>" }), "goods", "", "", "PUT")
	}

};
function Connector() {
}

Connector.Ajax = function (parm, url, succ, error = (x) => alertify.error(x.message), method = "POST") {
	$.ajax(window.GURL + url, {
		data: parm,
			type: method
		}).done(function (result) {
			if (succ && typeof succ === 'function') {
				succ(Connector.FromJson(result));
			} else {
				console.log("нет Делегата!>>>	", Connector.FromJson(result));
			}
		}).fail(function (e) {
			if (e.message === null || e.message === undefined) e.message = 'Произошла ошибка выполнения запроса';
			console.log(e.message);
			if (error && typeof (error) === 'function') {
				error(e);
			}
		});
	}
Connector.FromJson = function(v) {
		if ((typeof v === 'string') && ((v.indexOf("{") >= 0) || (v.indexOf("[") >= 0) || (v.indexOf(":") >= 0))) {
			try {
				return JSON.parse(v);
			}
			catch (e) {
				return v;
			}
		} else {
			return v;
		}
	}
