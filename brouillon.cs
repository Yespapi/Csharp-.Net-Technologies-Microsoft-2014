using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;

namespace WpfApplication8

abstract class Shape 
{
	pbulic Shape(Canvas canvs)
	{
		_canvas =canvas;
	}

	public virtual void Draw() {
		double left =_canvas.Actual.Width * _rand.NextDouble();
		double top = _canvas.ActualHeight *  _rand.NexDouble();
		_element.SetValue(Canvas.LeftProperty, left);
		_element.SetValue(Canvas.TopProperty, top);
		_canvas.Chirldren.Add(_element);
	}

	private Canvas _canvas;
	protected System.Windows.Shapes.Shape _element;
	statc Random _rand = new Random();
}
//herite de Shape
class Circle : Shape
	public Circle(Canvas canvas)
		:base(canvas)
		{
			Ellipse elippse = new Ellispe();
			ellispe.Width=10;
			ellispe.Height=10;
			eLlippse.Fill = new SolidColorBrushh(Colors.Green);
			ellipse.Stroke = new SolidColorBrush(Colors.Black);
			_element =elleipse;
		}

	public override void Draw()
		{
			elemeent.Fill =new SolidColorBrush(Colors.red);
			base.Draw();
		}

class Square : Shape
{
	public Square(Canvas canvas)
		:base(canvas)
		{
			Rectangle rect=new Rectangle();
			rect.Width=10;
			rect.Height=10;
			rect.Fill=new SolidColorBrush(Colors.Green);
			rect.Stroke =new  SolidColoorBrush(Colors.Black);
			_element = rect;
		}
	}
}
/******************************le main ********************/

void MainWindow_Loaded(object sender, RouteEventArgs e)
{
	Shape s1 = new Square(DrawingCanvas);
	Circle s2= new Circle(DrawingCanvas);
	Shape s3 = new Circle(DrawingCanvas);
	s1.Draw ; s2.Draw(); S3.Draw();
	for(int i=0; i<100; i++)
	{
		DrawSphape(new Square(DrawingCanvas));
		Drawshape(new Circle(DrawingCanvas));
	}
	private void DrawShape(Shape shape)
	{
		shape.Draw();
	}
}			