/********************************************************************************
** Form generated from reading UI file 'mainwindow.ui'
**
** Created by: Qt User Interface Compiler version 6.10.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_MAINWINDOW_H
#define UI_MAINWINDOW_H

#include <QtCore/QVariant>
#include <QtGui/QAction>
#include <QtGui/QIcon>
#include <QtWidgets/QApplication>
#include <QtWidgets/QCommandLinkButton>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QMenu>
#include <QtWidgets/QMenuBar>
#include <QtWidgets/QStatusBar>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_MainWindow
{
public:
    QAction *action;
    QAction *action_Bug;
    QAction *action_PRS;
    QAction *action11;
    QWidget *centralwidget;
    QCommandLinkButton *commandLinkButton;
    QMenuBar *menubar;
    QMenu *menuPRS;
    QMenu *menu;
    QMenu *menu_2;
    QMenu *menu_3;
    QMenu *menu_4;
    QMenu *menu_5;
    QStatusBar *statusbar;

    void setupUi(QMainWindow *MainWindow)
    {
        if (MainWindow->objectName().isEmpty())
            MainWindow->setObjectName("MainWindow");
        MainWindow->resize(1000, 600);
        QIcon icon;
        icon.addFile(QString::fromUtf8(":/images/logo.png"), QSize(), QIcon::Mode::Normal, QIcon::State::Off);
        MainWindow->setWindowIcon(icon);
        action = new QAction(MainWindow);
        action->setObjectName("action");
        action_Bug = new QAction(MainWindow);
        action_Bug->setObjectName("action_Bug");
        action_PRS = new QAction(MainWindow);
        action_PRS->setObjectName("action_PRS");
        action11 = new QAction(MainWindow);
        action11->setObjectName("action11");
        centralwidget = new QWidget(MainWindow);
        centralwidget->setObjectName("centralwidget");
        commandLinkButton = new QCommandLinkButton(centralwidget);
        commandLinkButton->setObjectName("commandLinkButton");
        commandLinkButton->setGeometry(QRect(360, 240, 171, 41));
        commandLinkButton->setIconSize(QSize(40, 40));
        commandLinkButton->setAutoDefault(false);
        commandLinkButton->setDefault(false);
        MainWindow->setCentralWidget(centralwidget);
        menubar = new QMenuBar(MainWindow);
        menubar->setObjectName("menubar");
        menubar->setGeometry(QRect(0, 0, 1000, 21));
        menuPRS = new QMenu(menubar);
        menuPRS->setObjectName("menuPRS");
        menu = new QMenu(menubar);
        menu->setObjectName("menu");
        menu_2 = new QMenu(menubar);
        menu_2->setObjectName("menu_2");
        menu_3 = new QMenu(menubar);
        menu_3->setObjectName("menu_3");
        menu_4 = new QMenu(menubar);
        menu_4->setObjectName("menu_4");
        menu_5 = new QMenu(menubar);
        menu_5->setObjectName("menu_5");
        MainWindow->setMenuBar(menubar);
        statusbar = new QStatusBar(MainWindow);
        statusbar->setObjectName("statusbar");
        MainWindow->setStatusBar(statusbar);

        menubar->addAction(menuPRS->menuAction());
        menubar->addAction(menu->menuAction());
        menubar->addAction(menu_2->menuAction());
        menubar->addAction(menu_3->menuAction());
        menubar->addAction(menu_4->menuAction());
        menubar->addAction(menu_5->menuAction());
        menuPRS->addAction(action);
        menu_5->addAction(action_Bug);
        menu_5->addAction(action_PRS);

        retranslateUi(MainWindow);

        QMetaObject::connectSlotsByName(MainWindow);
    } // setupUi

    void retranslateUi(QMainWindow *MainWindow)
    {
        MainWindow->setWindowTitle(QCoreApplication::translate("MainWindow", "PRS_Analyst", nullptr));
        action->setText(QCoreApplication::translate("MainWindow", "\345\257\274\345\207\272", nullptr));
        action_Bug->setText(QCoreApplication::translate("MainWindow", "\346\212\245\345\221\212Bug", nullptr));
        action_PRS->setText(QCoreApplication::translate("MainWindow", "\345\205\263\344\272\216PRS", nullptr));
        action11->setText(QCoreApplication::translate("MainWindow", "11", nullptr));
        commandLinkButton->setText(QCoreApplication::translate("MainWindow", "\345\257\274\345\205\245\344\277\241\345\217\267\346\226\207\344\273\266", nullptr));
        menuPRS->setTitle(QCoreApplication::translate("MainWindow", "\346\226\207\344\273\266", nullptr));
        menu->setTitle(QCoreApplication::translate("MainWindow", "\347\274\226\350\276\221", nullptr));
        menu_2->setTitle(QCoreApplication::translate("MainWindow", "\350\277\220\350\241\214", nullptr));
        menu_3->setTitle(QCoreApplication::translate("MainWindow", "\345\210\206\346\236\220", nullptr));
        menu_4->setTitle(QCoreApplication::translate("MainWindow", "\345\267\245\345\205\267", nullptr));
        menu_5->setTitle(QCoreApplication::translate("MainWindow", "\345\270\256\345\212\251", nullptr));
    } // retranslateUi

};

namespace Ui {
    class MainWindow: public Ui_MainWindow {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_MAINWINDOW_H
