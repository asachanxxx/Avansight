console.log("Inside IIFE");

var ctsFunctions = (function () {
    var $btnGenaratePatients,
        $iptsamplesize;

    function init() {
        $form = $('.frm-genarate-patient');
        $btnGenaratePatients = $('.btn-gen-patients');
        $iptsamplesize = $('.ipt-sample-size');

        $btnGenaratePatients.click(function (e) {
            console.log("$btnGenaratePatients clicked");
            validateForm();
        });

    }
    
    return {
        init,
        validateForm
    }
})();

