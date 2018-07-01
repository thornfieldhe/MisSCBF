var main = new Vue({
    el: "#main",
    mixins: [allMixin],
    ready: function () {
        var $this = this;         
        var datePickerDateFrom = $('#datePickerDateFrom').datepicker({ format: 'yyyy-mm-dd' }).on('changeDate', function (ev) {
            datePickerDateFrom.hide();
            $this.queryEntity.dateFrom = $("#datePickerDateFrom").val();
        })
        .on('hide', function (event) {
		        event.preventDefault();
		        event.stopPropagation();
	    })
        .data('datepicker');
        var datePickerDateTo = $('#datePickerDateTo').datepicker({ format: 'yyyy-mm-dd' }).on('changeDate', function (ev) {
            datePickerDateTo.hide();
            $this.queryEntity.dateTo = $("#datePickerDateTo").val();
        })
        .on('hide', function (event) {
		        event.preventDefault();
		        event.stopPropagation();
	    })
        .data('datepicker');
    },
    data: {
        queryEntity: {
            dateFrom:"",
            dateTo:""
        },
        list:[]
    },
    methods: {
        query: function (index) {
            var $this = this;
            abp.services.app.carRepairTime.getAll($this.queryEntity)
            .done(function (r) {
                    $this.list = r;
                })
            .fail(function (r) {
                $this.fail(r);
            });
        },
        resetSearch: function () {
                this.queryEntity.dateFrom="";
                this.queryEntity.dateTo="";
        }
    }
});



