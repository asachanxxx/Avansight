console.log("StudySelector Page Loaded");


var ctsFunctions = (function () {
    var $studyItems,
        $btnImport,
        $fileUpload,
       

    function init() {
        $(".btn-study").toggle();
        $studyItems = $(".studyItems");
        $btnImport = $(".btn-import");
        $fileUpload = $(".fileUpload");

        $btnImport.click(function () {
            $fileUpload.click();
        });

        $fileUpload.change(function () {
            var files = $(this).prop("files");
            formData = new FormData();
            formData.append("MyUploader", files[0]);

            jQuery.ajax({
                type: 'POST',
                url: "/Study/OnPostMyUploader",
                data: formData,
                cache: false,
                contentType: false,
                processData: false,
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("XSRF-TOKEN",
                        $('input:hidden[name="__RequestVerificationToken"]').val());
                },
                success: function (repo) {
                    if (repo.status == "success") {
                        alert("File : " + repo.filename + " is uploaded successfully");
                    }
                },
                error: function () {
                    alert("Error occurs");
                }
            });
        });
    }

    function template(response) {
        $studyItems.empty();
        var grouped = groupByCategory(response);
        console.log("grouped :- ", grouped);
        for (var k in grouped) {
            $studyItems.append(`
           <div class="col-6">
                <div class="card">
                    <div class="card-header">
                        <p class="mb-0">${k}</p>
                    </div>
                    <div class=" card-body">
                    <div class="row row-scroll">
                        ${grouped[k]}
                    </div>
                    </div>
                </div>
            </div>
            `);
        }
    }

    function groupByCategory(data) {
        var groups = {};
        $(data).each(function (k, v) {
            if (!(v.type in groups)) {
                groups[v.type] = "";
            }
            groups[v.type] = groups[v.type] +
                `<div class="col-4">
                    <div class="card card-inner-${v.studyId}">
                        <div class=" card-body">
                            <h5 class="card-title">${v.studyName}</h5>
                            <p class="card-text mb-1">Proj No: ${v.projectNumber}</p>
                            <p class="card-text">Study Identifire: ${v.studyIdentifier}</p>
                            <div class="row">
                                <div class="col-md-4">
                                    ID: ${v.studyId}
                                </div>
                                <div class="col-md-8">
                                    <a href="/Study/Index/${v.studyId}" class="btn btn-info btn-sm btn-study float-left">Navigate to Study</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                `;
        });
        return groups;
    }

    function loadStudyData() {
        $.ajax({
            type: "POST",
            url: "/Study/GetStudies",
            success: function (response) {
                template(response);
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
        loadStudyData,
    }
})();