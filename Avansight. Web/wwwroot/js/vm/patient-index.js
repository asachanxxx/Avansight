var ctsFunctions = (function () {
    var $container,
        $subjectSelector,
        $yearSlider,
        $chktgSelectTGroup,
        $chkGenSelect,
        $btnCancel,
        $btnApply,
        $rdoAllages,
        $rdobetween,
        patientData,
        person,
        chart,
        selectedTreatments,
        selectedTreatmentsAll,
        selectedGenders,
        selectedGendersAll,
        ageFrom,
        ageTo,
        allAgesFlag



    function init() {
        $container = $('.study-selector-container');
        $subjectSelector = $container.find('.subject-selector');
        $btnMenuToggl = $container.find('.btn-menu-toggle');
        $yearSlider = $(".year-slider");
        $chktgSelectTGroup = $container.find('.chktg-selectTGroup');
        $chkGenSelect = $container.find('.chkGen-select');
        $btnCancel = $container.find('.btn-cancel');
        $btnApply = $container.find('.btn-apply');
        $rdoAllages = $container.find('.rdo-allages');
        $rdobetween = $container.find('.rdo-between');
        selectedTreatments = [];
        selectedGenders = [];
        selectedTreatmentsAll = false;
        selectedGendersAll = false;
        ageFrom = 20;
        ageTo = 71;
        allAgesFlag = true;


        $subjectSelector.toggle();
        $btnMenuToggl.click(function () {
            $subjectSelector.toggle('show');
        });

        $btnCancel.click(function () {
            $subjectSelector.toggle();
        });

        $rdoAllages.change(function () {
            if (this.checked) {
                allAgesFlag = true;
                ageFrom = 20;
                ageTo = 71;
            }
        });

        $rdobetween.change(function () {
            console.log("this.checked", this.checked);
            if (this.checked) {
                allAgesFlag = false;
            }
        });

        $btnApply.click(function () {
            //create Person object to pass data
            person = {
                StudyId: 1,
                TreatmentCode: selectedTreatments,
                MinAge: ageFrom,
                MaxAge: ageTo,
                Gender: selectedGenders
            }
            //Trigger Ajax call 
            getPatient();
        });

        initUiControllers();

        person = {
            StudyId: 1,
            TreatmentCode: selectedGenders,
            MinAge: ageFrom,
            MaxAge: ageTo,
            Gender: selectedTreatments
        }

        getPatient();
        loadChart();
        
    }

    function onChange(checkboxes, checkedState) {
        if (checkedState == "all") {
            selectedTreatmentsAll = true;
            for (var i = 0; i < checkboxes.length; i++) {
                selectedTreatments.push(checkboxes[i].attr("id"));
            }
        } else {
            selectedTreatmentsAll = false;
            var box = checkboxes[0];
            if (box.prop("checked")) {
                selectedTreatments.push(box.attr("id"));
            } else {
                const index = selectedTreatments.indexOf(box.attr("id"));
                if (index > -1) {
                    selectedTreatments.splice(index, 1);
                }
            }
        }
    }

    function onChangechkGen(checkboxes, checkedState) {
        if (checkedState == "all") {
            selectedGendersAll = true;
            for (var i = 0; i < checkboxes.length; i++) {
                selectedGenders.push(checkboxes[i].attr("id"));
            }
        } else {
            selectedGendersAll = false;
            var box = checkboxes[0];
            if (box.prop("checked")) {
                selectedGenders.push(box.attr("id"));
            } else {
                const index = selectedGenders.indexOf(box.attr("id"));
                if (index > -1) {
                    selectedGenders.splice(index, 1);
                }
            }
        }
    }

    function initUiControllers() {
        $chktgSelectTGroup.selectAllCheckbox({
            checkboxesName: "chktg",
            onChangeCallback: onChange
        });

        $chkGenSelect.selectAllCheckbox({
            checkboxesName: "chkGen",
            onChangeCallback: onChangechkGen
        });

        $yearSlider.ionRangeSlider({
            type: "double",
            min: 20,
            max: 71,
            from: 20,
            to: 71,
            grid: true,
            onChange: function (data) {
                if (!allAgesFlag) {
                    ageFrom = data.from;
                }
            },

            onFinish: function (data) {
                if (!allAgesFlag) {
                    ageTo = data.to;
                }
            },
        });
    }
    function loadChart() {
        am4core.useTheme(am4themes_animated);

        // Create chart instance
        chart = am4core.create("chartdiv", am4charts.XYChart);
        // Add data
        chart.data = patientData;
        // Create axes
        var categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
        categoryAxis.dataFields.category = "gender";
        categoryAxis.renderer.grid.template.location = 0;
        //categoryAxis.renderer.minGridDistance = 30;

        var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());

        // Create series
        var series = chart.series.push(new am4charts.ColumnSeries());
        series.dataFields.valueY = "count";
        series.dataFields.categoryX = "gender";

    }
    function getPatient() {
        $.ajax({
            type: "POST",
            url: dataEndpoint,
            data: JSON.stringify(person),
            contentType: 'application/json',
            success: function (response) {
                console.log("response ", response);
                //save data for future use if any
                patientData = response;
                //assign data to chat data object
                chart.data = response;
                //Refresh the chart 
                chart.invalidateData();
            },
            failure: function (response) {
                console.error(response.responseText);
            },
            error: function (response) {
                console.error(response.responseText);
            }
        });
    }

    return {
        init,
        loadChart
    }
})();