$(document).ready(function () {
    // DataTable
    $('#articlesTable').DataTable({
        "order": [[4, "desc"]],
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
        },

    });
    // DataTable

    // Chart.js

    function createGradient(ctx, color1, color2) {
        const gradient = ctx.createLinearGradient(0, 0, 0, 400);
        gradient.addColorStop(0, color1);
        gradient.addColorStop(1, color2);
        return gradient;
    }

    $.get('/Admin/Article/GetAllByViewCount/?isAscending=false&takeSize=10', function (data) {
        const articleResult = jQuery.parseJSON(data);
        const ctx = document.getElementById('viewCountChart').getContext('2d');

        // Renk gradientleri
        const viewGradient = createGradient(ctx, '#8b5cf6', '#c4b5fd');
        const commentGradient = createGradient(ctx, '#fb923c', '#fed7aa');

        new Chart(ctx, {
            type: 'bar',
            data: {
                labels: articleResult.$values.map(article => article.Title),
                datasets: [{
                    label: 'Görüntülenme',
                    data: articleResult.$values.map(article => article.ViewsCount),
                    backgroundColor: viewGradient,
                    borderColor: '#7c3aed',
                    borderWidth: 1,
                    borderRadius: 8,
                    barThickness: 32,
                },
                {
                    label: 'Yorum',
                    data: articleResult.$values.map(article => article.CommentCount),
                    backgroundColor: commentGradient,
                    borderColor: '#f97316',
                    borderWidth: 1,
                    borderRadius: 8,
                    barThickness: 32,
                }]
            },
            options: {
                maintainAspectRatio: false,
                responsive: true,
                plugins: {
                    legend: {
                        position: 'top',
                        labels: {
                            color: '#374151',
                            font: {
                                size: 14,
                                family: 'Inter'
                            },
                            padding: 16,
                            usePointStyle: true,
                        }
                    },
                    tooltip: {
                        backgroundColor: '#1f2937',
                        titleFont: { size: 14 },
                        bodyFont: { size: 14 },
                        padding: 12,
                        cornerRadius: 8,
                        displayColors: false,
                        callbacks: {
                            title: (items) => items[0].label,
                            label: (item) => `${item.dataset.label}: ${item.formattedValue}`
                        }
                    }
                },
                scales: {
                    x: {
                        grid: {
                            display: false,
                            drawBorder: false
                        },
                        ticks: {
                            color: '#6b7280',
                            font: {
                                size: 12,
                                family: 'Inter'
                            },
                            maxRotation: 45,
                            minRotation: 45
                        }
                    },
                    y: {
                        beginAtZero: true,
                        grid: {
                            color: '#e5e7eb',
                            drawBorder: false
                        },
                        ticks: {
                            color: '#6b7280',
                            font: {
                                size: 12,
                                family: 'Inter'
                            },
                            padding: 16
                        }
                    }
                },
                interaction: {
                    mode: 'nearest',
                    intersect: false
                }
            }
        });
    });
    // Log Grafiği için
    function createLogGradient(ctx, color) {
        const gradient = ctx.createLinearGradient(0, 0, 0, 400);
        gradient.addColorStop(0, color + 'FF');
        gradient.addColorStop(1, color + '33');
        return gradient;
    }
    $.get('/Admin/Log/GetLogLevelStats', function (data) {
        const ctx = document.getElementById('logLevelChart').getContext('2d');

        // Canvas yüksekliğini burada artırıyoruz
        const canvas = document.getElementById('logLevelChart');
        canvas.height = 400;  // Yüksekliği daha da artırdık

        new Chart(ctx, {
            type: 'doughnut',
            data: {
                labels: Object.keys(data),
                datasets: [{
                    data: Object.values(data),
                    backgroundColor: [
                        '#ef4444', '#f59e0b', '#3b82f6', '#10b981', '#8b5cf6'
                    ],
                    borderWidth: 1,
                    hoverOffset: 6
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,  /* Grafik oranını korur */
                cutout: '70%',  /* Daha ince bir halka */
                plugins: {
                    legend: {
                        position: 'right',
                        labels: {
                            boxWidth: 10,
                            padding: 10,
                            font: {
                                size: 11
                            }
                        }
                    },
                    tooltip: {
                        bodyFont: {
                            size: 12
                        },
                        padding: 8
                    }
                },
                layout: {
                    padding: {
                        top: 5,
                        bottom: 5,
                        left: 5,
                        right: 5
                    }
                }
            }
        });
    });


});