$(document).ready(function () {

    // Trumbowyg

    $('#text-editor').trumbowyg({
        btns: [
            ['viewHTML'],
            ['undo', 'redo'], // Only supported in Blink browsers
            ['formatting'],
            ['strong', 'em', 'del'],
            ['superscript', 'subscript'],
            ['link'],
            ['insertImage', 'pasteImage'],
            ['justifyLeft', 'justifyCenter', 'justifyRight', 'justifyFull'],
            ['unorderedList', 'orderedList'],
            ['horizontalRule'],
            ['removeformat'],
            ['fullscreen'],
            ['foreColor', 'backColor'],
            ['emoji'],
            ['fontfamily'],
            ['fontsize'],
            ['table', 'tableCellBackgroundColor', 'tableBorderColor'],
            ['base64'],
            ['indent', 'outdent'],
            ['noembed']
        ],
        plugins: {
            color: {
                foreColorList: [
                    '#ff0000', '#00ff00', '#0000ff', '#54e346'
                ],
                backColorList: [
                    '000', '333', '555'
                ],
                displayAsList: false
            },
            pasteImage: {
                pasteInlineImages: true,
                minWidth: 100,
                maxWidth: 1000,
            },
            resizimg: {
                minSize: 64,
                step: 16,
            },
            table: {

            }
        }
    });

    // Trumbowyg

    // Select2

    $('#categoryList').select2({
        theme: 'bootstrap4',
        placeholder: "Lütfen bir kategori seçiniz...",
        allowClear: true
    });
    // Select2



    // JQuery-UI -DatePicker
    $(function () {
        $("#datepicker").datepicker({
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
            minDate: -3,
            maxDate: +3,

        });
    });
    // JQuery-UI -DatePicker
});