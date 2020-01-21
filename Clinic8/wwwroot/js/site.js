// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.
  
$(document).ready(function () {
    $("#dr_name").autoComplete({
        source:function(request, responce) {
            $.ajax({
                url: "/Patients/Search1",
                type: "POST",
                dataType: "json",
                data: { Prefix: request.term },
                success: function (data) {
                    responce($.map(data, function (item) {
                        return { lable: item, value: item };
                    }))
                }
            })
        },
        messages: {
        noResult:"" ,result:""
    }
    });
        })
        