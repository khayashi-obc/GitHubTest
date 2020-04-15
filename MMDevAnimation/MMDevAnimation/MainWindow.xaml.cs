using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MMDevAnimation
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		/// <summary>
		/// 
		/// </summary>
		private Storyboard menuSearchAnimation;

		public MainWindow()
		{
			InitializeComponent();
			this.CreateMenuSearchAnimation();
		}

		private void CreateMenuSearchAnimation()
		{
			// ＝＝＝＝＝＝＝＝＝＝＝StoryBoard利用＝＝＝＝＝＝＝＝＝＝＝
			this.menuSearch.Visibility = Visibility.Visible;

			// 透明度を変更するアニメーション
			var opacityAnimation2 = new DoubleAnimation();
			// どこから
			opacityAnimation2.From = 0.1;
			// どこまで
			opacityAnimation2.To = 1;
			// アニメーションの時間
			opacityAnimation2.Duration = new Duration(TimeSpan.FromSeconds(0.8));
			Storyboard.SetTarget(opacityAnimation2, this.menuSearch);
			Storyboard.SetTargetProperty(opacityAnimation2, new PropertyPath(Border.OpacityProperty));

			// 高さを変更するアニメーション
			var heightAnimation2 = new DoubleAnimation();
			// どこから
			heightAnimation2.From = 50;
			// どこまで
			heightAnimation2.To = 200;
			// アニメーションの時間
			heightAnimation2.Duration = new Duration(TimeSpan.FromSeconds(0.3));
			Storyboard.SetTarget(heightAnimation2, this.menuSearch);
			Storyboard.SetTargetProperty(heightAnimation2, new PropertyPath(Border.HeightProperty));

			// 幅を変更するアニメーション
			var widthAnimation2 = new DoubleAnimation();
			// どこから
			widthAnimation2.From = 50;
			// どこまで
			widthAnimation2.To = 150;
			// アニメーションの時間
			widthAnimation2.Duration = new Duration(TimeSpan.FromSeconds(0.2));
			Storyboard.SetTarget(widthAnimation2, this.menuSearch);
			Storyboard.SetTargetProperty(widthAnimation2, new PropertyPath(Border.WidthProperty));

			this.menuSearchAnimation = new Storyboard();
			this.menuSearchAnimation.Children.Add(opacityAnimation2);
			this.menuSearchAnimation.Children.Add(heightAnimation2);
			this.menuSearchAnimation.Children.Add(widthAnimation2);
			// ＝＝＝＝＝＝＝＝＝＝＝StoryBoard利用＝＝＝＝＝＝＝＝＝＝＝
		}
		/// <summary>
		/// 幅を変更
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void width_Click(object sender, RoutedEventArgs e)
		{
			this.menuList.Width = 150;
		}
		private void reset_Click(object sender, RoutedEventArgs e)
		{
		}
		/// <summary>
		/// 拡大
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void expand_Click(object sender, RoutedEventArgs e)
		{
			// ダブル型のプロパティに対するアニメーション（幅 ＝ Width ＝ Double型）
			var expandAnimation = new DoubleAnimation();
			// どこから
			expandAnimation.From = 30;
			// どこまで
			expandAnimation.To = 100;
			// アニメーションの時間
			expandAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));
			// アニメーションをやりっぱなしにする
			expandAnimation.AutoReverse = false;
			// アニメーション完了後にどうする
			expandAnimation.Completed += (s, args) =>
			{
				menuList.BorderBrush = new SolidColorBrush(Colors.DarkRed);
				menuList.BorderThickness = new Thickness(1);
			};

			this.menuList.BeginAnimation(Border.WidthProperty, expandAnimation);
		}
		/// <summary>
		/// 繰り返し
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void reserve_Click(object sender, RoutedEventArgs e)
		{
			// ダブル型のプロパティに対するアニメーション（幅 ＝ Width ＝ Double型）
			var expandAnimation = new DoubleAnimation();
			// どこから
			expandAnimation.From = 30;
			// どこまで
			expandAnimation.To = 100;
			// アニメーションの時間
			expandAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));

			// 繰り返し（元の状態まで遷移）
			expandAnimation.AutoReverse = true;

			this.menuList.BeginAnimation(Border.WidthProperty, expandAnimation);
		}

		/// <summary>
		/// フェードイン
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void fadeIn_Click(object sender, RoutedEventArgs e)
		{
			#region 既存のコード（複数のアニメーションを個別実行）
			// ＝＝＝＝＝＝＝＝＝＝＝既存のコード（複数のアニメーションを個別実行）＝＝＝＝＝＝＝＝＝＝＝
			//this.menuSearch.Visibility = Visibility.Visible;

			//// 透明度を変更するアニメーション
			//var opacityAnimation = new DoubleAnimation();
			//// どこから
			//opacityAnimation.From = 0.1;
			//// どこまで
			//opacityAnimation.To = 1;
			//// アニメーションの時間
			//opacityAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.8));

			//// 高さを変更するアニメーション
			//var heightAnimation = new DoubleAnimation();
			//// どこから
			//heightAnimation.From = 50;
			//// どこまで
			//heightAnimation.To = 200;
			//// アニメーションの時間
			//heightAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.3));

			//// 幅を変更するアニメーション
			//var widthAnimation = new DoubleAnimation();
			//// どこから
			//widthAnimation.From = 50;
			//// どこまで
			//widthAnimation.To = 150;
			//// アニメーションの時間
			//widthAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.2));

			//// 個別実行
			//this.menuSearch.BeginAnimation(Border.HeightProperty, heightAnimation);
			//this.menuSearch.BeginAnimation(Border.WidthProperty, widthAnimation);
			//this.menuSearch.BeginAnimation(Border.OpacityProperty, opacityAnimation);
			// ＝＝＝＝＝＝＝＝＝＝＝既存のコード（複数のアニメーションを個別実行）＝＝＝＝＝＝＝＝＝＝＝
			#endregion

			#region StoryBoard利用
			// ＝＝＝＝＝＝＝＝＝＝＝StoryBoard利用＝＝＝＝＝＝＝＝＝＝＝
			this.menuSearchAnimation.Begin();
			// ＝＝＝＝＝＝＝＝＝＝＝StoryBoard利用＝＝＝＝＝＝＝＝＝＝＝
			#endregion
		}

		private void reserveFadeIn_Click(object sender, RoutedEventArgs e)
		{
			this.menuSearch.Visibility = Visibility.Visible;

			// ダブル型のプロパティに対するアニメーション（幅 ＝ Width ＝ Double型）
			var opacityAnimation = new DoubleAnimation();
			// どこから
			opacityAnimation.From = 0.1;
			// どこまで
			opacityAnimation.To = 1;
			// アニメーションの時間
			opacityAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));

			// 繰り返し（元の状態まで遷移）
			opacityAnimation.AutoReverse = true;

			// アニメーション完了後の処理
			opacityAnimation.Completed += (s, args) =>
			{
				this.menuSearch.Visibility = Visibility.Collapsed;
			};

			this.menuSearch.BeginAnimation(Border.OpacityProperty, opacityAnimation);
		}
		/// <summary>
		/// スライド
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void slide_Click(object sender, RoutedEventArgs e)
		{
			// ダブル型のプロパティに対するアニメーション（幅 ＝ Width ＝ Double型）
			var translateTransform = new DoubleAnimation();
			// どこから
			translateTransform.From = -800;
			// どこまで
			translateTransform.To = 0;
			// アニメーションの時間
			translateTransform.Duration = new Duration(TimeSpan.FromSeconds(0.5));
			this.slidePage.RenderTransform.BeginAnimation(TranslateTransform.XProperty, translateTransform);
		}
		private void reserveSlide_Click(object sender, RoutedEventArgs e)
		{
			// ダブル型のプロパティに対するアニメーション（幅 ＝ Width ＝ Double型）
			var translateTransform = new DoubleAnimation();
			// どこから
			translateTransform.From = 0;
			// どこまで
			translateTransform.To = 800;
			// アニメーションの時間
			translateTransform.Duration = new Duration(TimeSpan.FromSeconds(0.5));
			this.slidePage.RenderTransform.BeginAnimation(TranslateTransform.XProperty, translateTransform);
		}

	}
}
