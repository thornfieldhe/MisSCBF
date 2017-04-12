var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
    },
    data: {
        queryEntity: {
            code:"", 
            column1:"", 
            note1:"", 
            column21:"", 
            note21:"", 
            column22:"", 
            note22:"", 
            column31:"", 
            note31:"", 
            column32:"", 
            note32:"", 
            column33:"", 
            note33:"", 
            column34:"", 
            note34:"", 
            column35:"", 
            note35:"", 
            column36:"", 
            note36:"", 
            column41:"", 
            note41:"", 
            column42:"", 
            note42:"", 
            column43:"", 
            note43:"", 
            column44:"", 
            note44:"", 
            column45:"", 
            note45:"", 
            column46:"", 
            note46:"", 
            column47:"", 
            note47:"", 
            column5:"", 
            note5:"" 
        }
    },
    events: {
        'onResetSearch': function () {
            this.queryEntity.code="";
            this.queryEntity.column1="";
            this.queryEntity.note1="";
            this.queryEntity.column21="";
            this.queryEntity.note21="";
            this.queryEntity.column22="";
            this.queryEntity.note22="";
            this.queryEntity.column31="";
            this.queryEntity.note31="";
            this.queryEntity.column32="";
            this.queryEntity.note32="";
            this.queryEntity.column33="";
            this.queryEntity.note33="";
            this.queryEntity.column34="";
            this.queryEntity.note34="";
            this.queryEntity.column35="";
            this.queryEntity.note35="";
            this.queryEntity.column36="";
            this.queryEntity.note36="";
            this.queryEntity.column41="";
            this.queryEntity.note41="";
            this.queryEntity.column42="";
            this.queryEntity.note42="";
            this.queryEntity.column43="";
            this.queryEntity.note43="";
            this.queryEntity.column44="";
            this.queryEntity.note44="";
            this.queryEntity.column45="";
            this.queryEntity.note45="";
            this.queryEntity.column46="";
            this.queryEntity.note46="";
            this.queryEntity.column47="";
            this.queryEntity.note47="";
            this.queryEntity.column5="";
            this.queryEntity.note5="";
        }
    },
    methods: {
        excuteQuery: function ($this) {
            abp.services.app.budgetReceipt.get(main.queryEntity)
                .done(function (r) {
                    $this.bindItems($this, r);
                });
        }
    }
});

main.query(0);
$(".fileUpload").liteUploader({
    script: "http://localhost:5011/BudgetReceipt/Upload"
})
    .on("lu:success", function (e, response) {
        console.log(response);
    });

$(".fileUpload").change(function () {
    $(this).data("liteUploader").startUpload();
});


