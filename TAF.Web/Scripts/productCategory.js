
setting = {
	data: {
		simpleData: {
			enable: true
		}
	},
	callback: {
		onClick: function(event, treeId, treeNode, clickFlag) {
			main.selectNode = treeNode;
			$("#addItemModal").modal("allowEdit");
		}
	}
},
setting2 = {
	data: {
		simpleData: {
			enable: true
		}
	},
	callback: {
		onClick: function(){}
	}
}

Vue.component("form-body", {
	mixins: [itemMixin],
	template: "#productCategoryFormBody",
	ready: function () {
		var $this = this;
		var order = $("#spinboxOrder").spinbox("value", 0);
		order.options.max = 100;
		order.options.min = 0;
	},
	data: function () {
		return {
			item: {
				category: "ProductCategory",
				name: "",
				pId: "",
				id: "",
				order:0
			}
		};
	},
	events: {
		'onSaveItem': function () {
			var $this = this;
			abp.services.app.layer.saveAsync($this.item)
			.done(function (m) {
				$this.done();
					main.loadTree();
				})
			.fail(function (m) {
				$this.fail(m);
			});
		},
		'onGetItem': function (id) {
			this.editModel = true;
			var $this = this;
			abp.services.app.layer.get(id)
				.done(function (m) {
					$this.item = m;
					$this.onAdd = false;
				})
			.fail(function (m) {
				$this.fail(m);
			});
		}
	},
	methods: {
		clearItem: function () {
			this.onAdd = true;
			this.order = 0;
			this.name = "";
			this.pId = "";
			$('#spinboxOrder').spinbox('value', 0);
			this.onAdd = false;
		}
	}
});

var main = new Vue({
	el: "#main",
	ready: function () {
		this.loadTree();
	},
	data: {
		queryEntity: {
			category: "ProductCategory"
		}
	},
	events: {},
	methods: {
		newItem: function() {
			$("#addItemModal").modal("show");
			this.$broadcast('onAddItem', "新增");
		},
		loadTree: function () {
			var $this = this;
			abp.services.app.layer.getAllByCategory($this.queryEntity.category)
				.done(function (m) {
					$this.list = m;
					$this.treeNodes = m;
					$this.tree = $.fn.zTree.init($("#catalogTree"), setting, m);
					$this.tree.expandAll(true);
				});

		}
	}
});