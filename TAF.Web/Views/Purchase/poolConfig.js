var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
        var $this = this;
        $this.title = "设计单位";
        $this.category = "Purchase_DesignUnit";
        $this.queryEntity.category = $this.category;
        $("#myTab").on("shown.bs.tab", function (e) {
            var id = $(e.target).attr("id");
            if (id === "pdesignUnit") {
                $this.title = "设计单位";
                $this.category = "Purchase_DesignUnit";
            } else if (id === "ppartyA") {
                $this.title = "甲方代表";
                $this.category = "Purchase_PartyA";
            } else if (id === "pcostUnit") {
                $this.title = "造价单位";
                $this.category = "Purchase_CostUnit";
            } else if (id === "pconstructionControlUnit") {
                $this.title = "监理单位";
                $this.category = "Purchase_ConstructionControlUnit";
            } else if (id === "pbiddingAgency") {
                $this.title = "招标代理单位";
                $this.category = "Purchase_BiddingAgency";
            } else if (id === "pexpert") {
                $this.title = "评标专家";
                $this.category = "Purchase_Expert";
            } 
            $this.queryEntity.category = $this.category;
            $this.query(0);
        });
    },
    data: {
        selectItem:[],
        category: '',
        title: ''
    },
    events: {

    },
    methods: {
        query: function () {
            var $this = this;
            $this.selectItem = [];
            abp.services.app.unitPool.getAll($this.category)
                .done(function (r) {
                    $this.bindItems($this, r);
                    $this.selectItem = _.map(_.filter($this.list, function(r) { return r.isSelected == true; }),function(r){return r.itemId});
                });
        },
        save: function () {
            var $this = this;
            var input = { category: $this.category, ids: $this.selectItem };
            abp.services.app.unitPool.saveAsync(input)
                .done(function(r) {
                    $this.query();
                    taf.notify.success($this.title+"抽取范围修改成功");
                })
        }
    }
});


main.query();
function mapSaveItem(n) {
    return n.itemId;
}


