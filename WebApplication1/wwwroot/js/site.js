// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/*window.addEventListener("load", (e) => {
	try {
		//if (GURL)
		Connector.GMODEL.fillAll();
	}
	catch (e) {
		console.log(e, ">>");
	}
}
);*/

DevExpress.localization.locale(navigator.language);
function model() {
	let obj = this;
	this.goods = [];
	this.pharms = [];
	this.stores = [];
	this.lots = [];
	this.GoodsByPharm = [];
	this.fillAll = async function () {
		await obj.S("goods");
		await obj.S("pharms");
		await obj.S("stores");
		await obj.S("lots");
		await obj.S("goods/GoodsByPharm");
	};
	this.S = async function (what = "", parms = {}) {
		let res;
		try {
			res = await Connector.Ajax(parms, what, "GET");
			if (!res.success) {
				console.log(res); alertify.error(res.description);
			} else {
				obj[what.replace("goods/", "")] = Connector.FromJson(res.payload);
			}
		} catch (e) {
			res.success = false;
			res.description = e.description;
			res.payload = [];
			console.log(e); alertify.error(e.message);
		}
		return res;
	};
	this.D = async function (what = "", id) {
		let res;
		try {
			res = await Connector.Ajax(JSON.stringify({ id: id }), what, "DELETE");
			if (!res.success) {
				console.log(res); alertify.error(res.description);
			} else {
				Connector.DeleteRecordById(obj[what], id);
			}
		}
		catch (e) {
			res.success = false;
			res.description = e.description;
			res.payload = [];
			console.log(e); alertify.error(e.message);
		}
		return res;
	};
	this.IU = async function (what = "", parm) {
		let res;
		try {
			res = await Connector.Ajax(JSON.stringify(parm), what, "PUT");
			if (!res.success) {
				console.log(res); alertify.error(res.description);
			} else {
				Connector.updateRecordById(obj[what], parm.id, res.payload[0]);
			}
		}
		catch (e) {
			res.success = false;
			res.description = e.description;
			res.payload = [];
			console.log(e); alertify.error(e.message);
		}
		return res;
	}
}

function Connector() {
};

Connector.GMODEL = new model();
Connector.Ajax = async function (parm, url, method = "POST") {
	let res = { success: true, description: "", code: 0, payload: [] };
	try {
		res = await $.ajax(GURL + url, {
			data: parm,
			type: method
		});
	} catch (e) {
		res.success = false;
		res.description = e.description;
		res.payload = [];
	}
	return res;
};

Connector.FromJson = function (v) {
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
};
Connector.DeleteRecordById = function (arr, elementId) {
	ret = false;
	let i = arr.findIndex((x) => x.id == elementId);
	if (i && i >= 0) {
		ret = true;
		arr.splice(i, 1);
	}
	return ret;
};
Connector.updateRecordById = function (arr, elementId, value) {
	ret = false;
	if (elementId == null) {
		ret = true;
		arr.push(value);
		return ret;
	}
	else {
		let i = arr.findIndex((x) => x.id == elementId);
		if (i && i >= 0) {
			ret = true;
			arr[i] = value;
		}
	}
	return ret;
};
Connector.UnionDataForUpdate = function (change, src) {

	for (let _ = Object.keys(src) - 1; _ >= 0; _--) {
		if (change[Object.keys(src)[_]]) {
			src[Object.keys(src)[_]] = chandge[Object.keys(src)[_]];
		}
	}
	return src;
};
Connector.operateRecordForUpdate = function (array, change, key) {
	let src = null;
	let i = array.findIndex((x) => x.id == key);
	if (i >= 0) {
		src = array[i];
	}
	if (src) {
		for (let _ = Object.keys(src).length - 1; _ >= 0; _--) {
			if (change && change[Object.keys(src)[_]]) {
				src[Object.keys(src)[_]] = change[Object.keys(src)[_]];
			}
		}
	} return src;
}