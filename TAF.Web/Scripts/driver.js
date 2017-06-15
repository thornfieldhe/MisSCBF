Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#driverFormBody",
    ready: function () {
        var $this = this;
        var datePickerValidDrivingLicense = $('#datePickerValidDrivingLicense').datepicker({ format: 'yyyy-mm-dd' }).on('changeDate', function (ev) {
            datePickerValidDrivingLicense.hide();
            $this.item.validDrivingLicense = $("#datePickerValidDrivingLicense").val();
        })
        .on('hide', function (event) {
		        event.preventDefault();
		        event.stopPropagation();
	    })
        .data('datepicker');
        $("#searchEditLevel").select2()
            .on("change", function (e) {
                $this.item.level = $("#searchEditLevel").val(); });            
    },
    data: function () {
        return {
            item: {
                id: "00000000-0000-0000-0000-000000000000",            
                name: "",
                soldierId: "",
                validDrivingLicense: "",
                drivingLicense: "",
                level: "",
                phoneNumber: ""
            }
        };
    },
    events: {
        'onSaveItem': function (closeModal) {
            var $this = this;
            abp.services.app.driver.saveAsync($this.item)
            .done(function (m) {
                $this.done(closeModal);
            })
            .fail(function (m) {
                $this.fail(m);
            });
        },
        'onGetItem': function (id) {
            this.editModel = true;
            var $this = this;
            abp.services.app.driver.get(id)
                .done(function (m) {
                    $this.item = m;
                    $("#searchEditLevel").select2().val($this.item.level).trigger("change");
                })
            .fail(function (m) {
                $this.fail(m);
            });
        }
    },
    methods: {
        clearItem: function () {
            this.item.id = "00000000-0000-0000-0000-000000000000";
            this.item.name= "";
            this.item.soldierId= "";
            this.item.validDrivingLicense= "";
            this.item.drivingLicense= "";
            this.item.level= "";
            $("#searchEditlevel").select2().val("").trigger("change");
            this.item.phoneNumber= "";
        }
    }
});


var main = new Vue({
    mixins: [indexMixin],
    data: {
        queryEntity: {
            name:"", 
            soldierId:"", 
            validDrivingLicenseFrom:"", 
            validDrivingLicenseTo:"", 
            drivingLicense:"", 
            level:"", 
            phoneNumber:"" 
        }
    },
    methods: {
        excuteQuery: function ($this) {
            abp.services.app.driver.getAll(main.queryEntity)
                .done(function (r) {
                    $this.bindItems($this, r);
                });
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.driver.delete(id)
                .done(function (m) {
                    $this.done();
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        }
    }
});

main.query(0);



