var business = function () {
    return {
        //populate Sub Process list para: process Id
        populatSubProcess: function (processId) {
            $.ajax({
                url: '/api/transaction/GetSubProcessByProcessId/' + processId,
                type: "Get",
                error: function (xhr, textStatus, error) {
                    alert('error loading api : GetSubProcessByProcessId ');
                },
                cache: false,
                success: function (data) {
                    $(".subProcess select,.classification select").select2('data', null);
                    $(".subProcess select,.classification select").find('option').remove();
                    $(".subProcess select,.classification select").append("<option value='" + "" + "'>" + "</option>");
                    for (var i = 0; i < data.length; i++) {
                        $(".subProcess select").append("<option value='" + data[i].Value + "'>" + data[i].Text + "</option>");
                    }
                }
            });
        },
        // populate Classification. param: subProcess Id
        populateClassification: function (subProcessId) {
            $.ajax({
                url: '/api/transaction/GetClassificationBySubProcessId/' + subProcessId,
                type: "Get",
                error: function (xhr, textStatus, error) {
                    alert('error loading api : GetClassificationBySubProcessId ');
                },
                cache: false,
                success: function (data) {
                    $(".classification select").select2('data', null);
                    $(".classification select").find('option').remove();
                    $(".classification select").append("<option value='" + "" + "'>" + "</option>");
                    for (var i = 0; i < data.length; i++) {
                        $(".classification select").append("<option value='" + data[i].Value + "'>" + data[i].Text + "</option>");
                    }
                }
            });
        },
        //add initial select value
        prepopulate: function (element, title) {
            $(element).select2({
                placeholder: title,
                allowClear: true
            });
        },
        //populate document mapping by node id
        populateDocumentMapping: function (nodeId) {
     
                $.ajax({
                    url: '/api/transaction/GetDocumentMappingByNode/' + nodeId,
                    type: "Get",
                    data: { id: nodeId },
                    cache: false,
                    error: function (xhr, textStatus, error) {
                        alert('error loading GetDocumentMappingByNode api');
                    },
                    success: function (data) {
                        $("#mapping table tr ,#mapping table thead").remove();
                        if (data.length > 0) {
                            $("#mapping table").append("<thead><tr><td>Document</td><td>Mandatory</td><td>Active</td><td></td></tr></thead>");
                            for (var i = 0; i < data.length; i++) {
                                $("#mapping table").append("<tr id='" + data[i].DocumentId + "'>" + "<td>" + data[i].Name + "</td><td>" + data[i].Mandatory + "</td><td>" + data[i].Active + "</td><td class='delete'>" + "<a><span style='color:#666' class='glyphicon glyphicon-trash pointer'></span></a>" + "</td></tr>");
                            }
                        }
                        else {
                            $("#mapping table").append("<tr>" + "<td>" + "No available data." + "</td></tr>");
                        }
                    }
                });
            
        },
        //populate workflow mapping by node id
        populateWorkflowMapping: function (nodeId) {

            $.ajax({
                url: '/api/transaction/GetWorkflowMappingByNode/' + nodeId,
                type: "Get",
                data: { id: nodeId },
                cache: false,
                error: function (xhr, textStatus, error) {
                    alert('error loading GetWorkflowMappingByNode api');
                },
                success: function (data) {
                    $("#mapping table tr ,#mapping table thead").remove();
                    if (data.length > 0) {
                        $("#mapping table").append("<thead><tr><td>Level</td><td>Assignee</td><td>SLA (in days)</td><td></td></tr></thead>");
                        for (var i = 0; i < data.length; i++) {
                            $("#mapping table").append("<tr id='" + data[i].Assignee + "'>" + "<td class='level'>" + i + "</td><td>" + data[i].Assignee + "</td><td>" + data[i].SLA + "</td><td>" + data[i].Active + "</td><td class='delete'>" + "<a><span style='color:#666' class='glyphicon glyphicon-trash pointer'></span></a>" + "</td></tr>");
                        }
                        business.activateSorting();
                    }
                    else {
                        $("#mapping table").append("<tr>" + "<td>" + "No available data." + "</td></tr>");
                    }
                }
            });

        },
        //search document mapping
        searchDocumentMapping: function (workflow, process, subProcess, classification) {
            $.ajax({
                url: '/api/transaction/GetNodeId/',
                type: "Get",
                cache: false,
                data: { workflow: workflow, process: process, subProcess: subProcess, classification: classification },
                error: function (xhr, textStatus, error) {
                    alert('error getting GetNodeId api');
                },
                success: function (data) {
                    business.populateDocumentMapping(data.NodeId);
                }
            });
        },
        //search document mapping
        searchWorkflowMapping: function (workflow, process, subProcess, classification) {
            $.ajax({
                url: '/api/transaction/GetNodeId/',
                type: "Get",
                cache: false,
                data: { workflow: workflow, process: process, subProcess: subProcess, classification: classification },
                error: function (xhr, textStatus, error) {
                    alert('error getting GetNodeId api');
                },
                success: function (data) {
                    business.populateWorkflowMapping(data.NodeId);
                }
            });
        },
        //set value to select options
        preSelectOptions: function (nodeId) {
            $.ajax({
                url: '/api/transaction/GetNodeById/' + nodeId,
                type: "Get",
                data: { id: nodeId },
                cache: false,
                error: function (xhr, textStatus, error) {
                    alert('error getting GetNodeById api');
                },
                success: function (data) {
                    $("#ProcessId").select2("val", data.ProcessName);
                    $("#SubProcessId").select2("val", data.SubProcessName);
                    $("#ClassificationId").select2("val", data.ClassificatioName);
                }
            });
        },
        //remove an item
        removeItem: function (element, closestElement) {
            $(element).closest(closestElement).remove();

            //var i = -1;
            //$('#WorkflowTable').find('tr').each(function () {
            //    $(this).find('td.level').empty().append(i++);
            //});
        },


        //activate table dnd : sorting
        activateSorting: function () {
            debugger;
            $("#mapping #WorkflowTable").tableDnD();
            $("#WorkflowTable").tableDnD({
                onDragClass: "tDnD_whileDrag",
                onDrop: function (table, row) {
                    //var rows = table.tBodies[0].rows;
                    //var ids = "";
                    //for (var i = 0; i < rows.length; i++) {                       
                    //    alert(rows[i].id);
                    //}
                    //$("#mapping table tr td.level").empty();
                    //$(" tr").each(function () {
                    //    $("#mapping #WorkflowTable tr").find('tr.level').remove();
                    //});
                    var i = -1;
                    $(table).find('tr').each(function () {
                        $(this).find('td.level').empty().append(i++);
                    });
                },

            });

        },


        //main transaction
        save: function (url) {
            $.ajax({
                url: url,
                type: "post",
                cache: false,
                data: $('form').serialize(),
                beforeSend: function () {
                    $('form').validate().form();
                },
                complete: function (data) {                
                },
                error: function (data) {
                },
                success: function (data) {
                    //saved
                    if (data.code == '000') {
                        $('#mainModal').modal('hide');
                        $('#DataTable').jtable('load');
                        //add notification
                        $('#panel-status').removeClass().addClass('panel fade in panel-success');
                        $('#general-status').empty().append(data.message + data.content);
                        $('#alert').addClass('hide');

                        //disable code modification
                        $('#Code').attr('disabled', 'disabled');
                        $('#SecuredId').val(data.result);
                      
                    }
                    //modified
                    else if (data.code == '001') {
                        $('#mainModal').modal('hide');
                        $('#DataTable').jtable('load');
                        //add notification
                        $('#panel-status').removeClass().addClass('panel fade in panel-success');
                        $('#general-status').empty().append(data.message + data.content);
                        $('#alert').addClass('hide');

                        //disable code modification
                        $('#Code').attr('disabled', 'disabled');
                        $('#SecuredId').val(data.result);

                    }
                        //invalid
                    else if (data.code == "007") {
                        //  $('#alert').removeClass('hide');
                        alert(data.result);

                    }
                        //existed
                    else if (data.code == "003") {
                        $('#alert').removeClass('hide');
                        $('#notification').addClass('validation-summary-errors');
                        $('#notification').empty().append('<ul><li>Code or Item already exists!</li></ul>');
                        $('div.validation-summary-errors').addClass('hide');
                       
                    }
                        //error
                    else if (data.code == "005") {
                        $('#alert').removeClass('hide');
                        $('#general-status').empty().append('Error has occured!' + data.message);
                        
                    }

                }
            });

        },
        add: function (url)
        {
            $.ajax({
                url: url,
                type: "post",
                data: $('form').serialize(),
                beforeSend: function () {
                    $('form').validate().form();
                },
                complete: function (data) {
                },
                error: function (data) {
                },
                success: function (data) {
                    if (data.code == "003") {
                        $('#alert').removeClass('hide');
                        $('#notification').addClass('validation-summary-errors');
                        $('#notification').empty().append('<ul><li>Item has alredy been added!</li></ul>');
                        $('div.validation-summary-errors').addClass('hide');
                    }
                    else if (data.code == "007") {
                        $('#alert').removeClass('hide');

                    }
                    else {
                        $('#data-list').html(data);
                        $('#alert').addClass('hide');
                    }
                }
            });
        },

    };
}();


$(function () {

    //add select values
    $('#SLA').numeric();
    business.prepopulate("div.process select", "Select a process");
    business.prepopulate("div.subProcess select", "Select a Sub process");
    business.prepopulate("div.classification select", "Select a classification");
    //process on change
    $("#ProcessId").on("change", function (event) {
        event.preventDefault();
        var processId = $(this).val() != '' ? $(this).val() : '0';
        business.populatSubProcess(processId);
        return false;
    });
    //sub process on change
    $("#SubProcessId").on("change", function (event) {
        event.preventDefault();
        var subProcessId = $(this).val() != '' ? $(this).val() : '0';
        business.populateClassification(subProcessId);
        return false;
    });
    //search document Mapping
    $("#btnSearchDocumentMapping").on("click", function (event) {
        event.preventDefault();
        var workflow = $("#Id").val()
        var process = $("#ProcessId").val();
        var subProcess = $("#SubProcessId").val();
        var classification = $("#ClassificationId").val();    
        business.searchDocumentMapping(workflow, process, subProcess, classification);
        return false;
    });
    //search workflow Mapping
    $("#btnSearchWorkflowMapping").on("click", function (event) {
        event.preventDefault();
        var workflow = $("#Id").val()
        var process = $("#ProcessId").val();
        var subProcess = $("#SubProcessId").val();
        var classification = $("#ClassificationId").val();
        business.searchWorkflowMapping(workflow, process, subProcess, classification);
        business.activateSortiing();
        return false;
    });
    //populate mappung
    //business.populateDocumentMapping($('#NodeId').val());
    //remove an item from the mapping
    $(document).on("click", "#mapping table tr td.delete a", function (e) {
        e.preventDefault();
        business.removeItem($(this),'tr');
        return false;
    });

    //save and next
    //main workflow transaction
    // post: save
    $("#workflow #btnSave").click(function (event) {
        event.preventDefault();
        business.save('/workflow/New');
    });

    $("#workflow #btnNext").click(function (event) {
        event.preventDefault();
        window.location = '/DocumentMapping/Index/' + $("#SecuredId").val();
    });

    //document mapping// workflow mapping// notificaiton mapping
    $("#btnAdd").click(function (event) {
        event.preventDefault();
        business.add('/documentmapping/New');
    });



    
    




































    //add docu
    //$(document).on("click", "#btnAdd", function (e) {
    //    e.preventDefault();
    //    var document = $("#DocumentId").val();
    //    var exist = $("#mapping table tr#" + document);
    //    alert(exist);
    //    return false;
    //});
    
  
   


    

    //function clearForm() {
    //    $("#Assignee, #NoticeTo, #Operator").select2('data', null);
    //    $("#SLA").val("0");
    //}

   

    //$("#btnAddLevel").click(function (event) {
    //    event.preventDefault();
    //    $.ajax({
    //        url: add,
    //        type: "post",
    //        data: $('form').serialize(),
    //        beforeSend: function () {
    //            $('form').validate().form();
    //        },
    //        complete: function (data) {
    //            clearForm();
    //        },
    //        error: function (data) {
    //        },
    //        success: function (data) {
               
    //            if (data.code == "003") {
    //                $('#alert').removeClass('hide');
    //                $('#notification').addClass('validation-summary-errors');
    //                $('#notification').empty().append('<ul><li>Item has alredy been added!</li></ul>');
    //                $('div.validation-summary-errors').addClass('hide');
    //            }
    //            else if (data.code == "007") {
    //                $('#alert').removeClass('hide');

    //            }
    //            else {
    //                $('#data-list').html(data);
    //                $('#alert').addClass('hide');
    //                activateTableDND();
                    
    //            }
    //        }
    //    });
    //});




    //function getMaximumSelectionSize(no) {
    //    $("#Assignee").select2({
    //        maximumSelectionSize: no
    //    });
    //    $("#NoticeTo").select2({
    //        maximumSelectionSize: no
    //    });
    //}

    //getMaximumSelectionSize(1);
    //$("#options").change(function (event) {
    //    event.preventDefault();
    //    var options = $("#options").val();
    //    clearForm();
    //    if ($(this)[0].options[1].selected) {
    //        $("#operator-container").removeClass('hide');
    //        $("#note-assignee").empty().append('Specify multiple approvers at current level.');
    //        getMaximumSelectionSize(10);
    //    }
    //    if ($(this)[0].options[0].selected) {
    //        $("#operator-container").addClass('hide');
    //        $("#note-assignee").empty().append('Specify single approver at current level');
    //        $("#Assignee").select2('data', null);
    //        getMaximumSelectionSize(1);
    //    }

    //});

    //document mapping// workflow mapping// notificaiton mapping
    //$("#btnAdd").click(function (event) {
    //    event.preventDefault();
    //    $.ajax({
    //        url: add,
    //        type: "post",
    //        data: $('form').serialize(),
    //        beforeSend: function () {
    //            $('form').validate().form();
    //        },
    //        complete: function (data) {
    //        },
    //        error: function (data) {
    //        },
    //        success: function (data) {           
    //             if (data.code == "003") {
    //                $('#alert').removeClass('hide');
    //                $('#notification').addClass('validation-summary-errors');
    //                $('#notification').empty().append('<ul><li>Item has alredy been added!</li></ul>');
    //                $('div.validation-summary-errors').addClass('hide');
    //            }
    //            else if (data.code == "007") {
    //                $('#alert').removeClass('hide');
                 
    //            }
    //            else {
    //                $('#data-list').html(data);
    //                $('#alert').addClass('hide');
    //            }
    //        }
    //    });
    //});






    //// skip
    //$("#btnSkip").click(function (event) {
    //    event.preventDefault();
    //    window.location = redirectAction + "/Index/" + $("#SecuredId").val();
    //});

    //// post: save changes
    //$("#btnModify").click(function (event) {
    //    event.preventDefault();
    //    $.ajax({
    //        url: manage,
    //        type: "post",
    //        cache: false,
    //        data: $('form').serialize(),
    //        beforeSend: function () {
    //            $('form').validate().form();
    //        },
    //        complete: function (data) {
    //        },
    //        error: function (data) {
    //            alert('error');
    //        },
    //        success: function (data) {
    //            //saved
    //            if (data.code == '000') {
    //                $('#mainModal').modal('hide');
    //                $('#DataTable').jtable('load');
    //                //add notification
    //                $('#panel-status').removeClass().addClass('panel fade in panel-success');
    //                $('#general-status').empty().append(data.message + data.content);
    //                $('#alert').addClass('hide');
                    
    //            }
    //                //invalid
    //            else if (data.code == "007") {
    //                $('#alert').removeClass('hide');
    //                $('#general-status').empty().append('Required field!');
    //            }
    //                //existed
    //            else if (data.code == "003") {
    //                $('#alert').removeClass('hide');
    //                $('#general-status').empty().append('Item already exists!');
    //            }
    //                //error
    //            else if (data.code == "005") {
    //                $('#alert').removeClass('hide');
    //                $('#general-status').empty().append('Error has occured!' + data.message);
    //            }

    //        }
    //    });
    //});

    



});