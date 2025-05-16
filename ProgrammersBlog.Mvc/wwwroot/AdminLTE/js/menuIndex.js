$(document).ready(function () {

    /* DataTables start here. */

    const dataTable = $('#menusTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        "order": [[6, "desc"]],
        buttons: [
            {
                text: 'Ekle',
                attr: {
                    id: "btnAdd",
                },
                className: 'btn btn-success',
                action: function (e, dt, node, config) {
                }
            },
            {
                text: 'Yenile',
                className: 'btn btn-warning',
                action: function (e, dt, node, config) {
                    $.ajax({
                        type: 'GET',
                        url: '/Admin/Menu/GetAllMenus/',
                        contentType: "application/json",
                        beforeSend: function () {
                            $('#menusTable').hide();
                            $('.spinner-border').show();
                        },
                        success: function (data) {
                            const menuListDto = jQuery.parseJSON(data);
                            dataTable.clear();
                            console.log(menuListDto);
                            if (menuListDto.ResultStatus === 0) {
                                $.each(menuListDto.Menus.$values,
                                    function (index, menu) {
                                        const newTableRow = dataTable.row.add([
                                            menu.Id,
                                            menu.Name,
                                            menu.Url,
                                            menu.Order,
                                            menu.ParentId ? menu.ParentId : "Ana Menü",
                                            menu.IsActive ? "Evet" : "Hayır",
                                            menu.IsDeleted ? "Evet" : "Hayır",
                                            menu.Note,
                                            convertToShortDate(menu.CreatedDate),
                                            menu.CreatedByName,
                                            convertToShortDate(menu.ModifiedDate),
                                            menu.ModifiedByName,
                                            `
                                <button class="btn btn-primary btn-sm btn-update" data-id="${menu.Id}"><span class="fas fa-edit"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${menu.Id}"><span class="fas fa-minus-circle"></span></button>
                                            `
                                        ]).node();
                                        const jqueryTableRow = $(newTableRow);
                                        jqueryTableRow.attr('name', `${menu.Id}`);
                                    });
                                dataTable.draw();
                                $('.spinner-border').hide();
                                $('#menusTable').fadeIn(1400);
                            } else {
                                toastr.error(`${menuListDto.Message}`, 'İşlem Başarısız!');
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            $('.spinner-border').hide();
                            $('#menusTable').fadeIn(1000);
                            toastr.error(`${err.responseText}`, 'Hata!');
                        }
                    });
                }
            }
        ],
        language: {
            "sDecimal": ",",
            "sEmptyTable": "Tabloda herhangi bir veri mevcut değil",
            "sInfo": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
            "sInfoEmpty": "Kayıt yok",
            "sInfoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Sayfada _MENU_ kayıt göster",
            "sLoadingRecords": "Yükleniyor...",
            "sProcessing": "İşleniyor...",
            "sSearch": "Ara:",
            "sZeroRecords": "Eşleşen kayıt bulunamadı",
            "oPaginate": {
                "sFirst": "İlk",
                "sLast": "Son",
                "sNext": "Sonraki",
                "sPrevious": "Önceki"
            },
            "oAria": {
                "sSortAscending": ": artan sütun sıralamasını aktifleştir",
                "sSortDescending": ": azalan sütun sıralamasını aktifleştir"
            },
            "select": {
                "rows": {
                    "_": "%d kayıt seçildi",
                    "0": "",
                    "1": "1 kayıt seçildi"
                }
            }
        }
    });

    /* DataTables end here */

    /* Ajax GET / Getting the _MenuAddPartial as Modal Form starts from here. */

    $(function () {
        const url = '/Admin/Menu/Add/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $('#btnAdd').click(function () {
            $.get(url).done(function (data) {
                placeHolderDiv.html(data);
                placeHolderDiv.find(".modal").modal('show');
            });
        });

        /* Ajax GET / Getting the _MenuAddPartial as Modal Form ends here. */

        /* Ajax POST / Posting the FormData as MenuAddDto starts from here. */

        placeHolderDiv.on('click',
            '#btnSave',
            function (event) {
                event.preventDefault();
                const form = $('#form-menu-add');
                const actionUrl = form.attr('action');
                const dataToSend = form.serialize();
                $.post(actionUrl, dataToSend).done(function (data) {
                    console.log(data);
                    const menuAddAjaxModel = jQuery.parseJSON(data);
                    console.log(menuAddAjaxModel);
                    const newFormBody = $('.modal-body', menuAddAjaxModel.MenuAddPartial);
                    placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                    const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        placeHolderDiv.find('.modal').modal('hide');
                        const newTableRow = dataTable.row.add([
                            menuAddAjaxModel.MenuDto.Menu.Id,
                            menuAddAjaxModel.MenuDto.Menu.Name,
                            menuAddAjaxModel.MenuDto.Menu.Url,
                            menuAddAjaxModel.MenuDto.Menu.Order,
                            menuAddAjaxModel.MenuDto.Menu.ParentId ? menuAddAjaxModel.MenuDto.Menu.ParentId : "Ana Menü",
                            menuAddAjaxModel.MenuDto.Menu.IsActive ? "Evet" : "Hayır",
                            menuAddAjaxModel.MenuDto.Menu.IsDeleted ? "Evet" : "Hayır",
                            menuAddAjaxModel.MenuDto.Menu.Note,
                            convertToShortDate(menuAddAjaxModel.MenuDto.Menu.CreatedDate),
                            menuAddAjaxModel.MenuDto.Menu.CreatedByName,
                            convertToShortDate(menuAddAjaxModel.MenuDto.Menu.ModifiedDate),
                            menuAddAjaxModel.MenuDto.Menu.ModifiedByName,
                            `
                                <button class="btn btn-primary btn-sm btn-update" data-id="${menuAddAjaxModel.MenuDto.Menu.Id}"><span class="fas fa-edit"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${menuAddAjaxModel.MenuDto.Menu.Id}"><span class="fas fa-minus-circle"></span></button>
                                            `
                        ]).node();
                        const jqueryTableRow = $(newTableRow);
                        jqueryTableRow.attr('name', `${menuAddAjaxModel.MenuDto.Menu.Id}`);
                        dataTable.draw();
                        toastr.success(`${menuAddAjaxModel.MenuDto.Message}`, 'Başarılı İşlem!');
                    } else {
                        let summaryText = "";
                        $('#validation-summary > ul > li').each(function () {
                            let text = $(this).text();
                            summaryText = `*${text}\n`;
                        });
                        toastr.warning(summaryText);
                    }
                });
            });
    });

    /* Ajax POST / Posting the FormData as MenuAddDto ends here. */

    /* Ajax POST / Deleting a Menu starts from here */

    $(document).on('click',
        '.btn-delete',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
            const menuName = tableRow.find('td:eq(1)').text();
            Swal.fire({
                title: 'Silmek istediğinize emin misiniz?',
                text: `${menuName} adlı menü silinecektir!`,
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Evet, silmek istiyorum.',
                cancelButtonText: 'Hayır, silmek istemiyorum.'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        data: { menuId: id },
                        url: '/Admin/Menu/Delete/',
                        success: function (data) {
                            const menuDto = jQuery.parseJSON(data);
                            if (menuDto.ResultStatus === 0) {
                                Swal.fire(
                                    'Silindi!',
                                    `${menuDto.Menu.Name} adlı menü başarıyla silinmiştir.`,
                                    'success'
                                );

                                dataTable.row(tableRow).remove().draw();
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `${menuDto.Message}`,
                                });
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            toastr.error(`${err.responseText}`, "Hata!")
                        }
                    });
                }
            });
        });

/* Ajax GET / Getting the _MenuUpdatePartial as Modal Form starts from here. */

    $(function() {
        const url = '/Admin/Menu/Update/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click',
            '.btn-update',
            function(event) {
                event.preventDefault();
                const id = $(this).attr('data-id');
                $.get(url, { menuId: id }).done(function(data) {
                    placeHolderDiv.html(data);
                    placeHolderDiv.find('.modal').modal('show');
                }).fail(function() {
                    toastr.error("Bir hata oluştu.");
                });
            });

    /* Ajax POST / Updating a Menu starts from here */

    placeHolderDiv.on('click',
        '#btnUpdate',
        function(event) {
            event.preventDefault();

            const form = $('#form-menu-update');
            const actionUrl = form.attr('action');
            const dataToSend = form.serialize();
            $.post(actionUrl, dataToSend).done(function(data) {
                const menuUpdateAjaxModel = jQuery.parseJSON(data);
                console.log(menuUpdateAjaxModel);
                const newFormBody = $('.modal-body', menuUpdateAjaxModel.MenuUpdatePartial);
                placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                if (isValid) {
                    const id = menuUpdateAjaxModel.MenuDto.Menu.Id;
                    const tableRow = $(`[name="${id}"]`);
                    placeHolderDiv.find('.modal').modal('hide');
                    dataTable.row(tableRow).data([
                        menuUpdateAjaxModel.MenuDto.Menu.Id,
                        menuUpdateAjaxModel.MenuDto.Menu.Name,
                        menuUpdateAjaxModel.MenuDto.Menu.Url,
                        menuUpdateAjaxModel.MenuDto.Menu.Order,
                        menuUpdateAjaxModel.MenuDto.Menu.ParentId ? menuUpdateAjaxModel.MenuDto.Menu.ParentId : "Ana Menü",
                        menuUpdateAjaxModel.MenuDto.Menu.IsActive ? "Evet" : "Hayır",
                        menuUpdateAjaxModel.MenuDto.Menu.IsDeleted ? "Evet" : "Hayır",
                        menuUpdateAjaxModel.MenuDto.Menu.Note,
                        convertToShortDate(menuUpdateAjaxModel.MenuDto.Menu.CreatedDate),
                        menuUpdateAjaxModel.MenuDto.Menu.CreatedByName,
                        convertToShortDate(menuUpdateAjaxModel.MenuDto.Menu.ModifiedDate),
                        menuUpdateAjaxModel.MenuDto.Menu.ModifiedByName,
                        `
                                <button class="btn btn-primary btn-sm btn-update" data-id="${menuUpdateAjaxModel
                        .MenuDto.Menu.Id}"><span class="fas fa-edit"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${menuUpdateAjaxModel
                        .MenuDto.Menu.Id}"><span class="fas fa-minus-circle"></span></button>
                                            `
                    ]);
                    tableRow.attr("name", `${id}`);
                    dataTable.row(tableRow).invalidate();
                    toastr.success(`${menuUpdateAjaxModel.MenuDto.Message}`, "Başarılı İşlem!");
                } else {
                    let summaryText = "";
                    $('#validation-summary > ul > li').each(function () {
                        let text = $(this).text();
                        summaryText = `*${text}\n`;
                    });
                    toastr.warning(summaryText);
                }
            }).fail(function(response) {
                console.log(response);
            });
        });

    });
});

function convertToShortDate(dateString) {
    const shortDate = new Date(dateString).toLocaleDateString('tr-TR');
    return shortDate;
}
