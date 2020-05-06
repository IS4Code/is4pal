IS4 Palette
==========

The IS4 Palette is a class of 256-color palettes, designed for use as a general-purpose palette for both computers and humans. It offers a diverse selection of colors with common tones, displayed intuitively in a 16×16 table.

## Algorithm

The computation starts by treating the color array as a 4D coordinate space, with each of the axes used for one color component. The components are red, green, blue, and intensity. Each color component has one of 4 possible values based on the position of the color.

The 3 color channels produce a palette of 64 colors. The intensity component is then used to subdivide every color into 4 colors with varying intensity, by subtracting a specific amount from all color channels, in steps of 1/12, to create a linear scale for all primary colors.

The exception to this rule are the colors produced when all RGB channels are 0. As the color is already black, decreasing its intensity has no effect, so as an exception, shades of gray close to black are stored in these positions.

## Parameters

The code has two parameters: permutation and gamma.

The permutation index (0 to 23) specifies the order of color components representing the axes, and so it only affects the structure and visualisation of the palette.

The gamma parameter is used to scale the (normally linearly spaced) colors to match a more suitable intensity curve. Values lower than 1 make the colors brighter, while values higher than 1 make them darker. The gamma value should be selected so that all colors are visually distinguishable from each other. A value around 0.725 is recommended.

## Properties

The resulting palette contains for every primary color (red, green, blue, cyan, magenta, yellow) 12 colors for shades from black to full and 2 more shades from full to white. In addition, there are 78 colors with full saturation and 78 with partial saturation, the remaining 16 colors are shades of gray from black to white.

## Examples

Visualisations of the palettes for gamma values of 0.25, 0.50, 0.75, 1.00, 1.25, 1.50, 1.75, and 2.00.

![0.25](https://github.com/IllidanS4/is4pal/blob/master/examples/0.25.png?raw=true)![0.50](https://github.com/IllidanS4/is4pal/blob/master/examples/0.50.png?raw=true)![0.75](https://github.com/IllidanS4/is4pal/blob/master/examples/0.75.png?raw=true)![1.00](https://github.com/IllidanS4/is4pal/blob/master/examples/1.00.png?raw=true)![1.25](https://github.com/IllidanS4/is4pal/blob/master/examples/1.25.png?raw=true)![1.50](https://github.com/IllidanS4/is4pal/blob/master/examples/1.50.png?raw=true)![1.75](https://github.com/IllidanS4/is4pal/blob/master/examples/1.75.png?raw=true)![2.00](https://github.com/IllidanS4/is4pal/blob/master/examples/2.00.png?raw=true)
