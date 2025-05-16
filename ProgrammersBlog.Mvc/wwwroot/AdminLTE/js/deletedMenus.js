$(document).ready(function () {

    /* DataTables start here. */

    const dataTable = $('#deletedMenusTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: [
            {
                text: 'Yenile',
                className: 'btn btn-warning',
                action: function (e, dt, node, config) {
                    $.ajax({
                        type: 'GET',
                        url: '/Admin/Menu/GetAllDeletedMenus/',
                        contentType: "application/json",
                        beforeSend: function () {
                            $('#deletedMenusTable').hide();
                            $('.spinner-border').show();
                        },
                        success: function (data) {
                            const deletedMenus = jQuery.parseJSON(data);
                            dataTable.clear();
                            console.log(deletedMenus);
                            if (deletedMenus.ResultStatus === 0) {
                                $.each(deletedMenus.Menus.$values,
                                    function (index, menu) {
                                        const newTableRow = dataTable.row.add([
                                            menu.Id,
                                            menu.Name,
                                            menu.Url,
                                            menu.Order,
                                            menu.ParentId ? menu.ParentId : "Ana Menü",
                                            menu.IsActive ? "Evet" : "Hayır",
                                            menu.IsDeleted ? "Evet" : "Hayır",
                                            convertToShortDate(menu.CreatedDate),
                                            menu.CreatedByName,
                                            convertToShortDate(menu.ModifiedDate),
                                            menu.ModifiedByName,
                                            `
                                <button class="btn btn-warning btn-sm btn-undo" data-id="${menu.Id}"><span class="fas fa-undo"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${menu.Id}"><span class="fas fa-minus-circle"></span></button>
                            `
                                        ]).node();
                                        const jqueryTableRow = $(newTableRow);
                                        jqueryTableRow.attr('name', `${menu.Id}`);
                                    });
                                dataTable.draw();
                                $('.spinner-border').hide();
                                $('#deletedMenusTable').fadeIn(1400);
                            } else {
                                toastr.error(`${deletedMenus.Menus.Message}`, 'İşlem Başarısız!');
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            $('.spinner-border').hide();
                            $('#deletedMenusTable').fadeIn(1000);
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

    /* UndoDelete */

    $(document).on('click',
        '.btn-undo',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
            let menuName = tableRow.find('td:eq(1)').text();
            Swal.fire({
                title: 'Arşivden geri getirmek istediğinize emin misiniz?',
                text: `${menuName} adlı menü arşivden geri getirilecektir!`,
                icon: 'question',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Evet, arşivden geri getirmek istiyorum.',
                cancelButtonText: 'Hayır, istemiyorum.'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        data: { menuId: id },
                        url: '/Admin/Menu/UndoDelete/',
                        success: function (data) {
                            const undoDeletedMenuResult = jQuery.parseJSON(data);
                            console.log(undoDeletedMenuResult);
                            if (undoDeletedMenuResult.ResultStatus === 0) {
                                Swal.fire(
                                    'Arşivden Geri Getirildi!',
                                    `${undoDeletedMenuResult.Message}`,
                                    'success'
                                );

                                dataTable.row(tableRow).remove().draw();
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `${undoDeletedMenuResult.Message}`,
                                });
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            toastr.error(`${err.responseText}`, "Hata!");
                        }
                    });
                }
            });
        });
    /* UndoDelete */
    /* HardDelete */

    $(document).on('click',
        '.btn-delete',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
            let menuName = tableRow.find('td:eq(1)').text();
            Swal.fire({
                title: 'Kalıcı olarak silmek istediğinize emin misiniz?',
                text: `${menuName} adlı menü kalıcı olarak silinecektir!`,
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Evet, kalıcı olarak silmek istiyorum.',
                cancelButtonText: 'Hayır, istemiyorum.'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        data: { menuId: id },
                        url: '/Admin/Menu/HardDelete/',
                        success: function (data) {
                            const hardDeleteResult = jQuery.parseJSON(data);
                            console.log(hardDeleteResult);
                            if (hardDeleteResult.ResultStatus === 0) {
                                Swal.fire(
                                    'Kalıcı olarak silindi!',
                                    `${hardDeleteResult.Message}`,
                                    'success'
                                );

                                dataTable.row(tableRow).remove().draw();
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `${hardDeleteResult.Message}`,
                                });
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            toastr.error(`${err.responseText}`, "Hata!");
                        }
                    });
                }
            });
        });
    /* HardDelete */
});

function convertToShortDate(dateString) {
    const shortDate = new Date(dateString).toLocaleDateString('tr-TR');
    return shortDate;
}
