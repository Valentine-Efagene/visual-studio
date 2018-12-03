from sympy import symbols, Matrix

a1, a2, a3, b1, b2, b3, c1, c2, c3, x, y, z = symbols('a1 a2 a3 b1 b2 b3 c1 c2 c3 x y z')

A = Matrix( [[a1,a2,a3],[b1,b2,b3],[c1,c2,c3]]) # Creates a matrix.
B = Matrix( [[x],[y],[z]])

print( A * B)