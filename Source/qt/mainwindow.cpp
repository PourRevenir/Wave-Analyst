#include "mainwindow.h"
#include "./ui_mainwindow.h"


// 构造函数
MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    // 设置图标大小（UI文件中已设为40x40，这里可调整）
    ui->commandLinkButton->setIconSize(QSize(100, 50));

    // 添加描述文本
    // ui->commandLinkButton->setText("点击导入信号文件进行分析");

    // 设置按钮样式
    ui->commandLinkButton->setStyleSheet(
        "QCommandLinkButton {"
        "  font-size: 20px;"
        "  color: #0066cc;"
        "}"
        "QCommandLinkButton:hover {"
        "  color: #004c99;"
        "}"
        );

    // centralwidget设置样式
    //ui->centralwidget->setStyleSheet(
    //    "background-color: #f5f5f5;"
    //   "background-image: radial-gradient(#cccccc 1px, transparent 1px);"
     //   "background-size: 20px 20px;"
    //    );

}

void MainWindow::on_commandLinkButton_clicked()
{
    // 打开文件对话框
    QString fileName = QFileDialog::getOpenFileName(this,
                                                    "导入信号文件",
                                                    QDir::homePath(),
                                                    "信号文件 (*.wav *.mp3 *.dat *.csv *.txt);;所有文件 (*.*)");

    if (!fileName.isEmpty()) {
        QMessageBox::information(this, "导入成功",
                                 QString("已导入文件: %1").arg(fileName));
        // 这里可以添加信号文件处理逻辑
    }
}



void MainWindow::onImportButtonClicked()
{
    // 打开文件对话框
    QString fileName = QFileDialog::getOpenFileName(this,
                                                    "导入信号文件",
                                                    QDir::homePath(),
                                                    "信号文件 (*.wav *.mp3 *.dat *.csv *.txt);;所有文件 (*.*)");
    if (!fileName.isEmpty()) {
        QMessageBox::information(this, "导入成功",
                                 QString("已导入文件: %1").arg(fileName));
        // 信号文件处理逻辑
        generateSignalPlot(fileName);


    }
}


void MainWindow::generateSignalPlot(const QString &fileName)
{/*
    // 使用您图片中的示例数据
    QVector<double> signalData = {2, 0, 1, 0, 1, 0, 1, -1, 0};
    QVector<double> timeAxis = {1, 2, 3, 4, 5, 6, 7, 8, 9};

    // 创建绘图控件
    if (!ui->customPlot) {
        ui->customPlot = new QCustomPlot(ui->centralwidget);
        QVBoxLayout *layout = new QVBoxLayout(ui->centralwidget);
        layout->addWidget(ui->customPlot);
    } else {
        ui->customPlot->clearGraphs();
    }

    // 绘制信号
    ui->customPlot->addGraph();
    ui->customPlot->graph(0)->setData(timeAxis, signalData);

    // 设置样式
    ui->customPlot->graph(0)->setPen(QPen(Qt::blue, 2));
    ui->customPlot->graph(0)->setScatterStyle(QCPScatterStyle(QCPScatterStyle::ssCircle, Qt::blue, 8));

    // 设置坐标轴
    ui->customPlot->xAxis->setLabel("时间 (t)");
    ui->customPlot->yAxis->setLabel("信号值 (s)");
    ui->customPlot->xAxis->setRange(0.5, 9.5);
    ui->customPlot->yAxis->setRange(-1.5, 2.5);

    // 设置网格
    ui->customPlot->xAxis->grid()->setVisible(true);
    ui->customPlot->yAxis->grid()->setVisible(true);

    // 在关键点添加标注
    for (int i = 0; i < signalData.size(); ++i) {
        QCPItemText *textLabel = new QCPItemText(ui->customPlot);
        textLabel->setPositionAlignment(Qt::AlignTop|Qt::AlignHCenter);
        textLabel->position->setCoords(timeAxis[i], signalData[i]);
        textLabel->setText(QString::number(signalData[i]));
        textLabel->setFont(QFont("Arial", 8));
    }
ui->customPlot->replot();
   */

}







MainWindow::~MainWindow()
{
    delete ui;
}


