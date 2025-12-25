#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QFileDialog>
#include <QMessageBox>
#include <QVBoxLayout>      // 布局
#include <QFileDialog>      // 文件对话框
#include <QMessageBox>      // 消息框
// #include "qcustomplot.h"    // QCustomPlot库


QT_BEGIN_NAMESPACE

namespace Ui {
class MainWindow;
}
QT_END_NAMESPACE




class MainWindow : public QMainWindow
{
    Q_OBJECT  //支持槽机制


    //Pimpl 设计模式
public:
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();

private slots:  // === 在这里声明槽函数 ===
    void onImportButtonClicked();
    void on_commandLinkButton_clicked();

private:
    Ui::MainWindow *ui;  // 指向UI界面的指针


    // 文件处理
private:
    void generateSignalPlot(const QString &fileName); // 生成图像
    void readSignalFile(const QString &fileName); //检测文件是否合格



//private:
    // QCustomPlot *customPlot;  // 手动声明

};










#endif // MAINWINDOW_H
