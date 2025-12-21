from PyQt5.QtWidgets import QApplication

from main_screen import MainScreen


def main():
    app = QApplication([])
    main_win = MainScreen(app)
    main_win.show()
    app.exec_()


if __name__ == "__main__":
    main()
