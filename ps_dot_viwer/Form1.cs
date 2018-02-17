using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace ps_dot_viwer
{
	public partial class Form1 : Form
	{
		private const string		CONFIG_PATH						= @".\config.xml";
		private const string		MESSAGE_FILELIST_WAIT			= @"Drag and Drop Here"; 
		private const string		MESSAGE_FILELIST_LOAD_WAIT		= "FileList Loading"; 
		private const string		MESSAGE_FILELIST_LOAD_COMPLETE	= "FileList Load OK";
		private const int			DEFAULT_TIMER_INTERVAL_MSEC		= 1000; 
		private const int			DEFAULT_WINDOW_X				= 0; 
		private const int			DEFAULT_WINDOW_Y				= 0; 
		private const int			DEFAULT_WINDOW_WIDTH			= 200; 
		private const int			DEFAULT_WINDOW_HEIGHT			= 200; 
		private const bool			DEFEAULT_IS_LOAD_SUB_DIRECTORY	= false;
		private const bool			DEFEAULT_IS_SCALE_DOWN			= false;
		private const ImageAnchor	DEFAULT_ANCHOR					= ImageAnchor.LeftUp;
		private readonly string[] SearchFileExtentions = { "bmp", "png", "jpg", "gif" };

		// うーん...
		private const int INTERVAL_1SEC		= 1000;
		private const int INTERVAL_2SEC		= 2000;
		private const int INTERVAL_5SEC		= 5000;
		private const int INTERVAL_10SEC	= 10000;
		private const int INTERVAL_15SEC	= 15000;
		private const int INTERVAL_20SEC	= 20000;
		private const int INTERVAL_30SEC	= 30000;
		private const int INTERVAL_60SEC	= 60000;

		// アンカー
		public enum ImageAnchor
		{
			LeftUp,
			LeftDown,
			RightUp,
			RightDown,
		};

		public class Config
		{
			public int Interval { get; set; }
			public int WindowX { get; set; }
			public int WindowY { get; set;}
			public int WindowWidth { get; set;}
			public int WindowHeight { get; set;}
			public bool IsLoadSubDirectory { get; set;}
			public bool IsScaleDown { get; set;}
			public ImageAnchor Anchor { get; set; }

			public void init()
			{
				Interval = DEFAULT_TIMER_INTERVAL_MSEC;
				WindowX = DEFAULT_WINDOW_X;
				WindowY = DEFAULT_WINDOW_Y;
				WindowWidth = DEFAULT_WINDOW_WIDTH;
				WindowHeight = DEFAULT_WINDOW_HEIGHT;
				IsLoadSubDirectory = DEFEAULT_IS_LOAD_SUB_DIRECTORY;
				IsScaleDown = DEFEAULT_IS_SCALE_DOWN;
				Anchor = DEFAULT_ANCHOR;
			}
		};

		// member
		private List<string> mFileList = null;
		private Bitmap mImage = null;
		private int mCurrentIndex = 0;
		private Point mMousePoint;
		private Rectangle mImageRect;
		private Config mConfig = null;
		private Timer mTimer = null;

		public Form1()
		{
			InitializeComponent();

			mFileList = new List<string>();
			mTimer = new Timer(); // Forms.Timer => UIスレッド動作

			contextMenu_1sec.Tag = INTERVAL_1SEC;
			contextMenu_2sec.Tag = INTERVAL_2SEC;
			contextMenu_5sec.Tag = INTERVAL_5SEC;
			contextMenu_10sec.Tag = INTERVAL_10SEC;
			contextMenu_15sec.Tag = INTERVAL_15SEC;
			contextMenu_20sec.Tag = INTERVAL_20SEC;
			contextMenu_30sec.Tag = INTERVAL_30SEC;
			contextMenu_60sec.Tag = INTERVAL_60SEC;

			contextMenu_leftup.Tag = ImageAnchor.LeftUp;
			contextMenu_leftdown.Tag = ImageAnchor.LeftDown;
			contextMenu_rightup.Tag = ImageAnchor.RightUp;
			contextMenu_rightdown.Tag = ImageAnchor.RightDown;

			addDelegate();
			loadSetting();
		}

		void addDelegate()
		{
			// Load
			this.Load += (object sender, EventArgs e) =>
			{
				this.Width = mConfig.WindowWidth;
				this.Height = mConfig.WindowHeight;
				this.Location = new Point(mConfig.WindowX, mConfig.WindowY);
				setMessage(MESSAGE_FILELIST_WAIT);
			};

			// FormClosing
			this.FormClosing += (object sender, FormClosingEventArgs e) =>
			{
				mConfig.WindowWidth = this.Width;
				mConfig.WindowHeight = this.Height;
				mConfig.WindowX = this.Location.X;
				mConfig.WindowY = this.Location.Y;

				saveSetting();
			};

			// MouseDown
			Action<object, MouseEventArgs> mouseDown = (object sender, MouseEventArgs e) =>
			{
				mMousePoint = new Point(e.X, e.Y);
			};
			this.MouseDown += new MouseEventHandler(mouseDown);
			pictureBox1.MouseDown += new MouseEventHandler(mouseDown);
			label_mesagge.MouseDown += new MouseEventHandler(mouseDown);

			// MouseMove
			Action<object, MouseEventArgs> mouseMove = (object sender, MouseEventArgs e) =>
			{
				if (e.Button != 0 && mMousePoint != null)
				{
					this.Location = new Point(
						this.Location.X + e.X - mMousePoint.X,
						this.Location.Y + e.Y - mMousePoint.Y);
				}
			};
			this.MouseMove += new MouseEventHandler(mouseMove);
			pictureBox1.MouseMove += new MouseEventHandler(mouseMove);
			label_mesagge.MouseMove += new MouseEventHandler(mouseMove);

			// Paint
			pictureBox1.Paint += (object sender, PaintEventArgs e) =>
			{
				if (mImage != null)
				{
					e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
					e.Graphics.DrawImage(mImage, mImageRect);
				}
			};

			// DragEnter
			this.DragEnter += (object sender, DragEventArgs e) =>
			{
				if (e.Data.GetDataPresent(DataFormats.FileDrop))
				{
					e.Effect = DragDropEffects.Copy;
				}
			};

			// DragDrop
			this.DragDrop += (object sender, DragEventArgs e) =>
			{
				string[] t = (string[])e.Data.GetData(DataFormats.FileDrop);
				startDrawImage(t);
			};

			// DoubleClick
			pictureBox1.DoubleClick += (object sender, EventArgs e) =>
			{
				System.Diagnostics.Process p = System.Diagnostics.Process.Start(mFileList[mCurrentIndex]);
			};

			// Click
			contextMenu_loadSubDirectory.Click += (object sender, EventArgs e) =>
			{
				mConfig.IsLoadSubDirectory = !mConfig.IsLoadSubDirectory;
				contextMenu_loadSubDirectory.Checked = mConfig.IsLoadSubDirectory;
			};
			contextMenu_scaleout.Click += (object sender, EventArgs e) =>
			{
				mConfig.IsScaleDown = !mConfig.IsScaleDown;
				contextMenu_scaleout.Checked = mConfig.IsScaleDown;
				resize();
			};
			contextMenu_end.Click += (object sender, EventArgs e) =>
			{
				Application.Exit();
			};
			contextMenu_1sec.Click += (object sender, EventArgs e) => { setInterval(INTERVAL_1SEC); };
			contextMenu_2sec.Click += (object sender, EventArgs e) => { setInterval(INTERVAL_2SEC); };
			contextMenu_5sec.Click += (object sender, EventArgs e) => { setInterval(INTERVAL_5SEC); };
			contextMenu_10sec.Click += (object sender, EventArgs e) => { setInterval(INTERVAL_10SEC); };
			contextMenu_15sec.Click += (object sender, EventArgs e) => { setInterval(INTERVAL_15SEC); };
			contextMenu_20sec.Click += (object sender, EventArgs e) => { setInterval(INTERVAL_20SEC); };
			contextMenu_30sec.Click += (object sender, EventArgs e) => { setInterval(INTERVAL_30SEC); };
			contextMenu_60sec.Click += (object sender, EventArgs e) => { setInterval(INTERVAL_60SEC); };
			contextMenu_border.Click += (object sender, EventArgs e) =>
			{
				this.FormBorderStyle = (contextMenu_border.Checked) ? FormBorderStyle.Sizable : FormBorderStyle.None;
				this.BackColor = (contextMenu_border.Checked || mFileList.Count == 0) ? Color.Lavender : Color.Fuchsia;
			};
			contextMenu_leftup.Click += (object sender, EventArgs e) => { setAnchor(ImageAnchor.LeftUp); };
			contextMenu_leftdown.Click += (object sender, EventArgs e) => { setAnchor(ImageAnchor.LeftDown); };
			contextMenu_rightup.Click += (object sender, EventArgs e) => { setAnchor(ImageAnchor.RightUp); };
			contextMenu_rightdown.Click += (object sender, EventArgs e) => { setAnchor(ImageAnchor.RightDown); };

			// Resize
			this.Resize += (object sender, EventArgs e) => { resize(); };

			// Tick
			mTimer.Tick += Timer_Tick;
		}


		//!< 設定ロード
		void loadSetting()
		{
			if (File.Exists(CONFIG_PATH))
			{
				var serialzier = new XmlSerializer(typeof(Config));
				using (var reader = new StreamReader(CONFIG_PATH))
				{
					mConfig = (Config)serialzier.Deserialize(reader);
				}
			}
			if (mConfig == null)
			{
				mConfig = new Config();
				mConfig.init();
			}

			setInterval(mConfig.Interval);
			setAnchor(mConfig.Anchor);
			contextMenu_loadSubDirectory.Checked = mConfig.IsLoadSubDirectory;
			contextMenu_scaleout.Checked = mConfig.IsScaleDown;
		}

		//!< 設定セーブ
		void saveSetting()
		{
			var serialzier = new XmlSerializer(typeof(Config));
			using (var writer = new StreamWriter(CONFIG_PATH, false, Encoding.UTF8))
			{
				serialzier.Serialize(writer, mConfig);
			}
		}

		//!< インターバル設定
		void setInterval(int interval)
		{
			ToolStripMenuItem[] items =
			{
				contextMenu_1sec,
				contextMenu_2sec,
				contextMenu_5sec,
				contextMenu_10sec,
				contextMenu_15sec,
				contextMenu_20sec,
				contextMenu_30sec,
				contextMenu_60sec,
			};

			foreach (var i in items)
			{
				i.Checked = ((int)(i.Tag) == interval);
			}

			mConfig.Interval = interval;
			mTimer.Interval = interval;
		}

		//!< アンカー設定
		void setAnchor(ImageAnchor anchor)
		{
			ToolStripMenuItem[] items =
			{
				contextMenu_leftup,
				contextMenu_leftdown,
				contextMenu_rightup,
				contextMenu_rightdown,
			};

			foreach (var i in items)
			{
				i.Checked = ((ImageAnchor)(i.Tag) == anchor);
			}
			mConfig.Anchor = anchor;
			resize();
		}

		//!< Form Loadイベント
		private async void startDrawImage(string[] directory)
		{
			mTimer.Stop();

			// FileList非同期ロード
			setMessage(MESSAGE_FILELIST_LOAD_WAIT);
			{
				await Task.Run(() => loadFileList(directory));

				if (mFileList.Count <= 0)
				{
					setMessage(MESSAGE_FILELIST_WAIT);
					return;
				}

				await Task.Run(() => updateImage(0));
			}
			setMessage(MESSAGE_FILELIST_LOAD_COMPLETE);
			label_mesagge.Visible = false;
			this.BackColor = Color.Fuchsia;

			mTimer.Start();
		}

		//!< Tick
		private async void Timer_Tick(object sender, EventArgs e)
		{
			mCurrentIndex++;
			if (mFileList.Count <= mCurrentIndex)
			{
				mCurrentIndex = 0;
			}
			await Task.Run(() => updateImage(mCurrentIndex));
		}

		//!< ファイルリストロード
		private void loadFileList(string[] directory)
		{
			mFileList.Clear();

			foreach (var path in directory)
			{
				getFileList(path, ref mFileList);
			}
			// shuffle
			mFileList = mFileList.OrderBy(i => Guid.NewGuid()).ToList();
		}

		//!< ファイルリスト取得(再帰関数)
		private void getFileList(string baseDirectory, ref List<string> outFileList)
		{
			if (!Directory.Exists(baseDirectory))
			{
				// not directory found
				return;
			}

			// Image File
			foreach (var extention in SearchFileExtentions)
			{
				var files = Directory.GetFiles(baseDirectory, "*." + extention);
				outFileList.AddRange(files);
			}

			// SubDirectory
			if (mConfig.IsLoadSubDirectory)
			{
				foreach( string directory in Directory.GetDirectories(baseDirectory) ){
					getFileList(directory, ref mFileList);	
				}
			}
		}

		//! 画像を更新
		private void updateImage(int index)
		{
			if (mFileList.Count <= index)
			{
				return;
			}

			if (mImage != null)
			{
				mImage.Dispose();
			}
			mImage = new Bitmap(mFileList[index]);

			// サイズ調整
			resize();
		}
		private void resize()
		{
			if (pictureBox1 != null && mImage != null)
			{
				mImageRect = getResizeRectangle(pictureBox1.Width, pictureBox1.Height, mImage.Width, mImage.Height);
				pictureBox1.Invalidate();
			}
		}

		private void setMessage(string message)
		{
			if (label_mesagge != null)
			{
				label_mesagge.Text = message;
				label_mesagge.Location = new Point(
					this.Width / 2 - label_mesagge.Width / 2,
					this.Height / 2);
			}
		}

		private Rectangle getResizeRectangle(int canvasWidth, int canvasHeight, int imageWidth, int imageHeight)
		{
			float scale = 1;

			// キャンバスより画像のほうが大きい
			if (imageWidth > canvasWidth || imageHeight > canvasHeight)
			{
				if (mConfig.IsScaleDown)
				{
					scale = Math.Min((float)canvasWidth / (float)imageWidth, (float)canvasHeight / (float)imageHeight);
				}
				else
				{
					scale = 1.0f;
				}
			}
			else
			{
				scale = Math.Min(canvasWidth / imageWidth, canvasHeight / imageHeight);
			}

			int x = 0;
			int y = 0;
			int w = (int)(imageWidth * scale);
			int h = (int)(imageHeight * scale);

			switch (mConfig.Anchor)
			{
				case ImageAnchor.LeftUp:
					x = 0;
					y = 0;
					break;
				case ImageAnchor.LeftDown:
					x = 0;
					y = canvasHeight - h;
					break;
				case ImageAnchor.RightUp:
					x = canvasWidth - w;
					y = 0;
					break;
				case ImageAnchor.RightDown:
					x = canvasWidth - w;
					y = canvasHeight - h;
					break;
			}
			return new Rectangle(x, y, w, h);
		}
	}
}
