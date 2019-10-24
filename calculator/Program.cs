using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace calculator {
	static class Program {
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}

	class MainForm : Form {
		private Button[] buttons = new Button[20];
		private TextBox textBox;
		
		public MainForm() {
			string[] buttonsText = {
				"C",
				"7", "8", "9", "/",
				"4", "5", "6", "*",
				"1", "2", "3", "-",
				".", "0", "=", "+"
			};
			int widthsize = 70;
			int heigthsize = 40;
			int butLocatWidthCount = 0;
			int butLocatHeigthCount = 0;
			int[] butLocatWidth = {10, 10 + widthsize, 10 + widthsize * 2, 10 + widthsize * 3};
			int[] butLocatHeigth = {heigthsize * 2, heigthsize * 3, heigthsize * 4, heigthsize * 5, heigthsize * 6};

			for (int i = 0; i < buttonsText.Length; i ++) {
				int width = 10;
				int heigth = heigthsize;

				if (i != 0) {
					if (butLocatWidthCount == 4) {
						butLocatWidthCount = 0;
						butLocatHeigthCount += 1;
					}

					if (butLocatWidthCount < butLocatWidth.Length) {
						width = butLocatWidth[butLocatWidthCount];
						heigth = butLocatHeigth[butLocatHeigthCount];
						butLocatWidthCount += 1;
					}
				}
				
				buttons[i] = new Button {
					Text = buttonsText[i],
					Size = new Size(widthsize, heigthsize),
					AutoSize = false,
					Location = new Point(width, heigth)
				};
				Console.WriteLine(buttons[i].Text);
				Console.WriteLine(buttons[i].Location);
			}
			textBox = new TextBox {
				Location = new Point(10, 0),
				Size = new Size(widthsize * butLocatWidth.Length, heigthsize),
				AutoSize = false,
			};
			this.Controls.Add(textBox);
			this.Controls.AddRange(buttons);

			this.Size = new Size(widthsize * (butLocatWidth.Length) + 40, heigthsize * (butLocatHeigth.Length + 2) + 10);
		}
	}
}
