using System;
using System.ComponentModel;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Export.Html;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Controls.Common
{
	[ToolboxItem(true)]
	public partial class XRichEditor : XtraUserControl
	{
		private bool mToolbarVisible = true;

		public XRichEditor()
		{
			InitializeComponent();
			Initialize();

			editor.EmptyDocumentCreated += delegate (object sender, EventArgs e)
			{
				InitFont();
			};
		}
		private void Initialize()
		{
			try
			{
				editor.BeginUpdate();
				editor.ActiveViewType = RichEditViewType.Simple;
				editor.Options.DocumentCapabilities.Bookmarks = DocumentCapability.Disabled;
				editor.Options.DocumentCapabilities.HeadersFooters = DocumentCapability.Disabled;
				editor.Options.DocumentCapabilities.Sections = DocumentCapability.Disabled;
				editor.Options.DocumentSaveOptions.DefaultFormat = DocumentFormat.Html;
				editor.Options.Export.Html.EmbedImages = true;
				editor.Options.Export.Html.HtmlNumberingListExportFormat = HtmlNumberingListExportFormat.PlainTextFormat;
				editor.Options.Export.Mht.HtmlNumberingListExportFormat = HtmlNumberingListExportFormat.PlainTextFormat;
				editor.Options.Fields.UseCurrentCultureDateTimeFormat = false;
				editor.Options.HorizontalRuler.Visibility = RichEditRulerVisibility.Hidden;
				editor.Options.MailMerge.KeepLastParagraph = false;
				editor.Options.VerticalRuler.Visibility = RichEditRulerVisibility.Hidden;

				InitFont();


				editor.EndUpdate();
			}
			catch
			{
			}
		}
		private void InitFont()
		{
			if (SkinUtils.GetFont("맑은 고딕") != null)
			{
				editor.Document.DefaultCharacterProperties.FontName = SkinUtils.GetFont("맑은 고딕").FontFamily.Name;
			}
			else
			{
				if (SkinUtils.GetFont("굴림") != null)
				{
					editor.Document.DefaultCharacterProperties.FontName = SkinUtils.GetFont("굴림").FontFamily.Name;
				}
				else
				{
					editor.Document.DefaultCharacterProperties.FontName = AppearanceObject.DefaultFont.FontFamily.Name;
				}
			}
		}
		private void InitPage()
		{
			for (var i = 0; i < editor.Document.Sections.Count; i++)
			{
				editor.Document.Sections[i].Page.PaperKind = System.Drawing.Printing.PaperKind.A4;
				editor.Document.Sections[i].Page.Landscape = true;
				editor.Document.Sections[i].Margins.Left = 1.0f;
			}
		}
		[Browsable(false)]
		public RichEditControl MainEditor
		{
			get
			{
				return editor;
			}
			set
			{
				editor = value;
			}
		}

		[Browsable(false)]
		public object EditValue
		{
			get
			{
				return editor.Document.RtfText;
			}
			set
			{
				editor.Document.RtfText = value.ToString();
			}
		}

		public bool ToolbarVisible
		{
			get
			{
				return mToolbarVisible;
			}
			set
			{
				commonBar.Visible =
					clipboardBar.Visible =
					stylesBar.Visible =
					fontBar.Visible =
					tablesBar.Visible =
					paragraphBar.Visible =
					editingBar.Visible = value;
			}
		}
		public bool ReadOnly
		{
			get
			{
				return editor.ReadOnly;
			}
			set
			{
				editor.ReadOnly = value;
			}
		}

		public void Clear()
		{
			editor.RtfText =
				editor.Text = null;
		}
	}
}
