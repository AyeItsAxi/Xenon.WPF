using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace Xenon.WPF.Common
{
    internal class AnimationHandler
    {
        /// <summary>
        /// Fades in an inputted XAML object
        /// </summary>
        /// <param name="targetObject">The object to fade in</param>
        /// <param name="timeToFade">The amount time to fade the object in</param>
        public static void FadeIn(DependencyObject targetObject, double timeToFade)
        {
            var bC = targetObject;
            var fadeC = new DoubleAnimation()
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(timeToFade),
            };
            Storyboard.SetTarget(fadeC, bC);
            Storyboard.SetTargetProperty(fadeC, new(UIElement.OpacityProperty));
            var sbC = new Storyboard();
            sbC.Children.Add(fadeC);
            sbC.Begin();
        }

        /// <summary>
        /// Fades an inputted XAML object to any opacity
        /// </summary>
        /// <param name="targetObject">The object to fade in</param>
        /// <param name="timeToFade">The amount time to fade the object in</param>
        /// <param name="originatingOpacity">The opacity at which the animation will start</param>
        /// <param name="targetOpacity">The opacity at which the animation will end</param>
        public static void FadeAnimation(DependencyObject targetObject, double timeToFade, double originatingOpacity, double targetOpacity)
        {
            var b = targetObject;
            var fade = new DoubleAnimation()
            {
                From = originatingOpacity,
                To = targetOpacity,
                Duration = TimeSpan.FromSeconds(timeToFade),
            };
            Storyboard.SetTarget(fade, b);
            Storyboard.SetTargetProperty(fade, new(UIElement.OpacityProperty));
            var sb = new Storyboard();
            sb.Children.Add(fade);
            sb.Begin();
        }
        /// <summary>
        /// Fades out an inputted XAML object
        /// </summary>
        /// <param name="targetObject">The object to fade out</param>
        /// <param name="timeToFade">The amount time to fade the object out</param>
        public static void FadeOut(DependencyObject targetObject, double timeToFade)
        {
            var b = targetObject;
            var fade = new DoubleAnimation()
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(timeToFade),
            };
            Storyboard.SetTarget(fade, b);
            Storyboard.SetTargetProperty(fade, new(UIElement.OpacityProperty));
            var sb = new Storyboard();
            sb.Children.Add(fade);
            sb.Begin();
        }

        /// <summary>
        /// Moves an XAML object to any position over a set amount of time
        /// </summary>
        /// <param name="targetObject">The object to move</param>
        /// <param name="time">The amount of time it will take for the object to reach it's destination</param>
        /// <param name="from">The original position of the object. Can be object.Margin</param>
        /// <param name="to">The destination the object will get to at the end of the time inputted</param>
        public static void MovementAnimation(DependencyObject targetObject, double time, Thickness from, Thickness to)
        {
            var b = targetObject;
            var fade = new ThicknessAnimation()
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromSeconds(time),
            };
            Storyboard.SetTarget(fade, b);
            Storyboard.SetTargetProperty(fade, new(FrameworkElement.MarginProperty));
            var sb = new Storyboard();
            sb.Children.Add(fade);
            sb.Begin();
        }
    }
}