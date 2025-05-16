$(document).ready(function () {
    // Select2
    $('#menuList').select2({
        theme: 'bootstrap4',
        placeholder: "Lütfen bir menü seçiniz...",
        allowClear: true
    });
    $('#filterByList').select2({
        theme: 'bootstrap4',
        placeholder: "Lütfen bir filtre türü seçiniz...",
        allowClear: true
    });
    $('#orderByList').select2({
        theme: 'bootstrap4',
        placeholder: "Lütfen bir sıralama türü seçiniz...",
        allowClear: true
    });
    $('#isAscendingList').select2({
        theme: 'bootstrap4',
        placeholder: "Lütfen bir sıralama tipi seçiniz...",
        allowClear: true
    });

    // jQuery UI - DatePicker
    $(function () {
        // DatePicker ayarları için temel konfigürasyon
        var datepickerOptions = {
            closeText: "kapat",
            prevText: "&#x3C;geri",
            nextText: "ileri&#x3e",
            currentText: "bugün",
            monthNames: ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran",
                "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"],
            monthNamesShort: ["Oca", "Şub", "Mar", "Nis", "May", "Haz",
                "Tem", "Ağu", "Eyl", "Eki", "Kas", "Ara"],
            dayNames: ["Pazar", "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi"],
            dayNamesShort: ["Pz", "Pt", "Sa", "Ça", "Pe", "Cu", "Ct"],
            dayNamesMin: ["Pz", "Pt", "Sa", "Ça", "Pe", "Cu", "Ct"],
            weekHeader: "Hf",
            dateFormat: "dd.mm.yy",
            firstDay: 1,
            isRTL: false,
            showMonthAfterYear: false,
            yearSuffix: "",
            duration: 1000,
            showAnim: "drop",
            showOptions: { direction: "down" },
            maxDate: 0
        };

        // Başlangıç tarihi DatePicker
        $("#startAtDatePicker").datepicker($.extend({}, datepickerOptions, {
            onSelect: function (selectedDate) {
                // Başlangıç tarihi değiştiğinde

                // 1. Bitiş tarihi için minimum değeri ayarla
                $("#endAtDatePicker").datepicker("option", "minDate", selectedDate);

                // 2. Mevcut bitiş tarihini al
                var endDateStr = $("#endAtDatePicker").val();

                // 3. Eğer bitiş tarihi boşsa, başlangıç tarihini ata
                if (!endDateStr || endDateStr.trim() === '') {
                    $("#endAtDatePicker").val(selectedDate);
                    return;
                }

                // 4. Tarihleri karşılaştır
                try {
                    var startDateParts = selectedDate.split('.');
                    var startDate = new Date(
                        parseInt(startDateParts[2]),
                        parseInt(startDateParts[1]) - 1,
                        parseInt(startDateParts[0])
                    );

                    var endDateParts = endDateStr.split('.');
                    var endDate = new Date(
                        parseInt(endDateParts[2]),
                        parseInt(endDateParts[1]) - 1,
                        parseInt(endDateParts[0])
                    );

                    // Eğer başlangıç tarihi bitiş tarihinden sonraysa veya aynıysa
                    if (startDate > endDate) {
                        // Bitiş tarihini manuel olarak input değeri olarak ayarla
                        $("#endAtDatePicker").val(selectedDate);
                    }
                } catch (e) {
                    console.error("Tarih karşılaştırma hatası:", e);
                    // Hata durumunda bitiş tarihini başlangıç tarihine eşitle
                    $("#endAtDatePicker").val(selectedDate);
                }
            }
        }));

        // Bitiş tarihi DatePicker
        $("#endAtDatePicker").datepicker(datepickerOptions);

        // Sayfa yüklendiğinde kontrolleri yap
        var startDateStr = $("#startAtDatePicker").val();
        if (startDateStr && startDateStr.trim() !== '') {
            // Başlangıç tarihi varsa minimum değeri ayarla
            $("#endAtDatePicker").datepicker("option", "minDate", startDateStr);

            // Bitiş tarihi boşsa veya başlangıç tarihinden küçükse güncelle
            var endDateStr = $("#endAtDatePicker").val();
            if (!endDateStr || endDateStr.trim() === '') {
                $("#endAtDatePicker").val(startDateStr);
            } else {
                try {
                    var startDateParts = startDateStr.split('.');
                    var startDate = new Date(
                        parseInt(startDateParts[2]),
                        parseInt(startDateParts[1]) - 1,
                        parseInt(startDateParts[0])
                    );

                    var endDateParts = endDateStr.split('.');
                    var endDate = new Date(
                        parseInt(endDateParts[2]),
                        parseInt(endDateParts[1]) - 1,
                        parseInt(endDateParts[0])
                    );

                    if (startDate > endDate) {
                        $("#endAtDatePicker").val(startDateStr);
                    }
                } catch (e) {
                    console.error("Başlangıç kontrol hatası:", e);
                }
            }
        }
    });
});

