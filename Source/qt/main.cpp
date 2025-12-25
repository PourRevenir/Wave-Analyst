#include "mainwindow.h"
#include <QtWidgets>
#include <QApplication>
#include <QLocale>
#include <QTranslator>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);




    // 启动页
    QPixmap pixmap(":/images/splash.png");
    QSplashScreen splash(pixmap);
    splash.show();
    // 模拟应用程序加载过程
    QThread::sleep(5);
    // 加载完成后关闭启动画面
    splash.finish(nullptr);


    //







    // 翻译
    QTranslator translator;
    const QStringList uiLanguages = QLocale::system().uiLanguages();
    for (const QString &locale : uiLanguages) {
        const QString baseName = "1_" + QLocale(locale).name();
        if (translator.load(":/i18n/" + baseName)) {
            a.installTranslator(&translator);
            break;
        }
    }



    MainWindow w;
    w.show();
    return a.exec();
}
