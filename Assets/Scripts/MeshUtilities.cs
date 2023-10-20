using System.Collections;
using UnityEngine;

public class MeshUtilities
{
    public static Mesh Cube(float size)
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[4 * 6]
        {
            //front
		    new Vector3(-size,-size,-size),
            new Vector3(size, -size, -size),
            new Vector3(size, size, -size),
            new Vector3(-size, size, -size),
            
            // back
            new Vector3(-size, -size, size),
            new Vector3(size, -size, size),
            new Vector3(size, size, size),
            new Vector3(-size, size, size),
            
            // left
            new Vector3(-size, -size, -size),
            new Vector3(-size, size, -size),
            new Vector3(-size, size, size),
            new Vector3(-size, -size, size),
            
            // right
            new Vector3(size, -size, -size),
            new Vector3(size, size, -size),
            new Vector3(size, size, size),
            new Vector3(size, -size, size),
            
            // bottom
            new Vector3(-size, -size, -size),
            new Vector3(-size, -size, size),
            new Vector3(size, -size, size),
            new Vector3(size, -size, -size),
            
            // top
            new Vector3(-size, size, -size),
            new Vector3(-size, size, size),
            new Vector3(size, size, size),
            new Vector3(size, size, -size)
        };
        mesh.vertices = vertices;

        Vector2[] uvs = new Vector2[4 * 6]
        {
            //front
            new Vector2(0.0f, 0.0f),
            new Vector2(0.5f, 0.0f),
            new Vector2(0.5f, 0.5f),
            new Vector2(0.0f, 0.5f),
            //back
            new Vector2(0.0f, 0.0f),
            new Vector2(0.5f, 0.0f),
            new Vector2(0.5f, 0.5f),
            new Vector2(0.0f, 0.5f),
            //left
            new Vector2(0.5f, 0.0f),
            new Vector2(1.0f, 0.0f),
            new Vector2(1.0f, 0.5f),
            new Vector2(0.5f, 0.5f),
            //right
            new Vector2(0.5f, 0.5f),
            new Vector2(1.0f, 0.5f),
            new Vector2(1.0f, 1.0f),
            new Vector2(0.5f, 1.0f),
            //bottom
            new Vector2(0.0f, 0.0f),
            new Vector2(0.5f, 0.0f),
            new Vector2(0.5f, 0.5f),
            new Vector2(0.0f, 0.5f),
            //top
            new Vector2(0.0f, 0.5f),
            new Vector2(0.5f, 0.5f),
            new Vector2(0.5f, 1.0f),
            new Vector2(0.0f, 1.0f),
        };
        mesh.uv = uvs;

        int[] tris = new int[6 * 2 * 3]
        {
            //front
            3, 2, 1,
            3, 1, 0,

            // back
            4,5,6,
            4,6,7,

            // left
            11,10,9,
            11,9,8,

            // right
            12,13,14,
            12,14,15,

            // bottom
            19,18,17,
            19,17,16,

            // top
            20,21,22,
            20,22,23
        };
        mesh.triangles = tris;
        mesh.RecalculateNormals();
        return mesh;
    }


    public static Mesh HexagonalBipyramid(float sideLength)
    {
        Mesh mesh = new Mesh();

        float h = Mathf.Sqrt(3) * sideLength / 2;

        // Vertices
        Vector3[] vertices = new Vector3[]
        {
            // Top triangles' vertices
            new Vector3(0, h, 0),
            new Vector3(sideLength / 2, 0, h),
            new Vector3(sideLength, 0, 0),

            new Vector3(0, h, 0),
            new Vector3(sideLength, 0, 0),
            new Vector3(sideLength / 2, 0, -h),

            new Vector3(0, h, 0),
            new Vector3(sideLength / 2, 0, -h),
            new Vector3(-sideLength / 2, 0, -h),

            new Vector3(0, h, 0),
            new Vector3(-sideLength / 2, 0, -h),
            new Vector3(-sideLength, 0, 0),

            new Vector3(0, h, 0),
            new Vector3(-sideLength, 0, 0),
            new Vector3(-sideLength / 2, 0, h),

            new Vector3(0, h, 0),
            new Vector3(-sideLength / 2, 0, h),
            new Vector3(sideLength / 2, 0, h),

            // Bottom triangles' vertices
            new Vector3(0, -h, 0),
            new Vector3(sideLength, 0, 0),
            new Vector3(sideLength / 2, 0, h),

            new Vector3(0, -h, 0),
            new Vector3(sideLength / 2, 0, -h),
            new Vector3(sideLength, 0, 0),

            new Vector3(0, -h, 0),
            new Vector3(-sideLength / 2, 0, -h),
            new Vector3(sideLength / 2, 0, -h),

            new Vector3(0, -h, 0),
            new Vector3(-sideLength, 0, 0),
            new Vector3(-sideLength / 2, 0, -h),

            new Vector3(0, -h, 0),
            new Vector3(-sideLength / 2, 0, h),
            new Vector3(-sideLength, 0, 0),

            new Vector3(0, -h, 0),
            new Vector3(sideLength / 2, 0, h),
            new Vector3(-sideLength / 2, 0, h)
        };

        mesh.vertices = vertices;

        Vector2[] uvs = new Vector2[36];

        // Top pyramid UVs
        uvs[0] = new Vector2(0.125f, 0.5f);
        uvs[1] = new Vector2(0, 0);
        uvs[2] = new Vector2(0.25f, 0);

        uvs[3] = new Vector2(0.375f, 0.5f);
        uvs[4] = new Vector2(0.25f, 0);
        uvs[5] = new Vector2(0.5f, 0);

        uvs[6] = new Vector2(0.625f, 0.5f);
        uvs[7] = new Vector2(0.5f, 0);
        uvs[8] = new Vector2(0.75f, 0);

        uvs[9] = new Vector2(0.875f, 0.5f);
        uvs[10] = new Vector2(0.75f, 0);
        uvs[11] = new Vector2(1.0f, 0);

        uvs[12] = new Vector2(0.875f, 1);
        uvs[13] = new Vector2(0.75f, 0.5f);
        uvs[14] = new Vector2(1.0f, 0.5f);

        uvs[15] = new Vector2(0.625f, 1);
        uvs[16] = new Vector2(0.5f, 0.5f);
        uvs[17] = new Vector2(0.75f, 0.5f);

        // Bottom pyramid UVs (Reversed colors)
        uvs[18] = new Vector2(0.625f, 1);
        uvs[19] = new Vector2(0.75f, 0.5f);
        uvs[20] = new Vector2(0.5f, 0.5f);

        uvs[21] = new Vector2(0.875f, 1);
        uvs[22] = new Vector2(1.0f, 0.5f);
        uvs[23] = new Vector2(0.75f, 0.5f);

        uvs[24] = new Vector2(0.875f, 0.5f);
        uvs[25] = new Vector2(1.0f, 0);
        uvs[26] = new Vector2(0.75f, 0);

        uvs[27] = new Vector2(0.625f, 0.5f);
        uvs[28] = new Vector2(0.75f, 0);
        uvs[29] = new Vector2(0.5f, 0);

        uvs[30] = new Vector2(0.375f, 0.5f);
        uvs[31] = new Vector2(0.5f, 0);
        uvs[32] = new Vector2(0.25f, 0);

        uvs[33] = new Vector2(0.125f, 0.5f);
        uvs[34] = new Vector2(0.25f, 0);
        uvs[35] = new Vector2(0, 0);

        mesh.uv = uvs;



        // Triangles (each group of 3 ints defines a triangle)
        int[] triangles = new int[36];
        for (int i = 0; i < 12; i++)
        {
            triangles[i * 3] = i * 3;
            triangles[i * 3 + 1] = i * 3 + 1;
            triangles[i * 3 + 2] = i * 3 + 2;
        }

        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }

    public static Mesh Torus(float mainRadius, float tubeRadius, int radialSegments, int tubularSegments)
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[(radialSegments + 1) * (tubularSegments + 1)];
        Vector2[] uvs = new Vector2[vertices.Length];
        int[] triangles = new int[radialSegments * tubularSegments * 6];

        for (int j = 0; j <= radialSegments; j++)
        {
            for (int i = 0; i <= tubularSegments; i++)
            {
                float u = i / (float)tubularSegments;
                float v = j / (float)radialSegments;

                float x = (mainRadius + tubeRadius * Mathf.Cos(v * 2.0f * Mathf.PI)) * Mathf.Cos(u * 2.0f * Mathf.PI);
                float y = tubeRadius * Mathf.Sin(v * 2.0f * Mathf.PI);
                float z = (mainRadius + tubeRadius * Mathf.Cos(v * 2.0f * Mathf.PI)) * Mathf.Sin(u * 2.0f * Mathf.PI);

                vertices[i + (j * (tubularSegments + 1))] = new Vector3(x, y, z);

                uvs[i + (j * (tubularSegments + 1))] = new Vector2(u, v * 0.5f);
            }
        }

        int index = 0;
        for (int j = 1; j <= radialSegments; j++)
        {
            for (int i = 1; i <= tubularSegments; i++)
            {
                triangles[index] = (tubularSegments + 1) * j + i - 1;
                triangles[index + 1] = (tubularSegments + 1) * (j - 1) + i;
                triangles[index + 2] = (tubularSegments + 1) * (j - 1) + i - 1;

                triangles[index + 3] = (tubularSegments + 1) * j + i - 1;
                triangles[index + 4] = (tubularSegments + 1) * j + i;
                triangles[index + 5] = (tubularSegments + 1) * (j - 1) + i;

                index += 6;
            }
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();

        return mesh;
    }


    public static Mesh Capsule(int radialSegments, int heightSegments, float radius, float height)
    {
        Mesh mesh = new Mesh();

        int vertexCount = 2 + radialSegments * (heightSegments + 1); // 2 centers + the main body
        int triangleCount = radialSegments * (2 + 2 * heightSegments); // caps + main body

        Vector3[] vertices = new Vector3[vertexCount];
        int[] triangles = new int[triangleCount * 3];

        // Top and bottom centers
        vertices[0] = new Vector3(0, height / 2, 0);
        vertices[1] = new Vector3(0, -height / 2, 0);

        int vertIndex = 2;
        int triIndex = 0;

        float dTheta = 2 * Mathf.PI / radialSegments;

        // Create capsule main body
        for (int i = 0; i <= heightSegments; i++)
        {
            float t = (float)i / heightSegments;
            float y = Mathf.Lerp(-height / 2 + radius, height / 2 - radius, t);

            for (int j = 0; j < radialSegments; j++)
            {
                float theta = j * dTheta;
                float x = radius * Mathf.Cos(theta);
                float z = radius * Mathf.Sin(theta);

                vertices[vertIndex] = new Vector3(x, y, z);

                if (i < heightSegments)
                {
                    triangles[triIndex] = vertIndex;
                    triangles[triIndex + 1] = (vertIndex + radialSegments) % (vertexCount - 2) + 2;
                    triangles[triIndex + 2] = (vertIndex + 1) % radialSegments + 2 + i * radialSegments;

                    triangles[triIndex + 3] = (vertIndex + 1) % radialSegments + 2 + i * radialSegments;
                    triangles[triIndex + 4] = (vertIndex + radialSegments) % (vertexCount - 2) + 2;
                    triangles[triIndex + 5] = (vertIndex + radialSegments + 1) % (vertexCount - 2) + 2;

                    triIndex += 6;
                }

                vertIndex++;
            }
        }

        // Create top cap
        for (int i = 0; i < radialSegments; i++)
        {
            triangles[triIndex] = 0;
            triangles[triIndex + 1] = (i + 1) % radialSegments + 2;
            triangles[triIndex + 2] = i + 2;

            triIndex += 3;
        }

        // Create bottom cap
        int bottomStartIndex = 2 + radialSegments * heightSegments;
        for (int i = 0; i < radialSegments; i++)
        {
            triangles[triIndex] = 1;
            triangles[triIndex + 1] = bottomStartIndex + i;
            triangles[triIndex + 2] = bottomStartIndex + (i + 1) % radialSegments;

            triIndex += 3;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }

    public static Mesh Cylinder(int d, float r, float h)
    {
        Mesh mesh = new Mesh();

        // Vertices
        Vector3[] vertices = new Vector3[4 * d + 2];
        float dTheta = Mathf.PI * 2.0f / d;
        for (int i = 0; i < d; i++)
        {
            float theta = i * dTheta;
            float x = r * Mathf.Cos(theta);
            float z = r * Mathf.Sin(theta);

            vertices[i] = new Vector3(x, h, z);             // Top vertices
            vertices[i + d] = new Vector3(x, -h, z);        // Bottom vertices

            // Repeated vertices for the caps
            vertices[i + 2 * d] = new Vector3(x, h, z);     // Top cap
            vertices[i + 3 * d] = new Vector3(x, -h, z);    // Bottom cap
        }

        // Center points for the caps
        vertices[4 * d] = new Vector3(0, h, 0);     // Top center
        vertices[4 * d + 1] = new Vector3(0, -h, 0);  // Bottom center

        mesh.vertices = vertices;

        // Triangles
        int[] tris = new int[d * 12];
        for (int i = 0; i < d; i++)
        {
            // Sides
            tris[i * 6] = i;
            tris[i * 6 + 1] = (i + 1) % d;
            tris[i * 6 + 2] = i + d;

            tris[i * 6 + 3] = i + d;
            tris[i * 6 + 4] = (i + 1) % d;
            tris[i * 6 + 5] = (i + 1) % d + d;

            // Top cap
            tris[d * 6 + i * 3] = 2 * d + i;
            tris[d * 6 + i * 3 + 1] = 4 * d;
            tris[d * 6 + i * 3 + 2] = 2 * d + (i + 1) % d;

            // Bottom cap
            tris[d * 9 + i * 3] = 3 * d + i;
            tris[d * 9 + i * 3 + 1] = 3 * d + (i + 1) % d;
            tris[d * 9 + i * 3 + 2] = 4 * d + 1;
        }

        mesh.triangles = tris;

        mesh.RecalculateNormals();

        return mesh;
    }



    public static Mesh Pyramid(float size)
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[5]
        {
        new Vector3(-size, 0, size),  // 0 (base front-left)
        new Vector3(size, 0, size),   // 1 (base front-right)
        new Vector3(size, 0, -size),  // 2 (base back-right)
        new Vector3(-size, 0, -size), // 3 (base back-left)
        new Vector3(0, size, 0),      // 4 (top vertex)
        };
        mesh.vertices = vertices;

        int[] tris = new int[6 * 3]
        {
        // Base
        0, 3, 2,
        0, 2, 1,

        // Sides
        0, 1, 4,
        1, 2, 4,
        2, 3, 4,
        3, 0, 4
        };
        mesh.triangles = tris;

        mesh.RecalculateNormals();
        return mesh;
    }



    public static Mesh Sweep(Vector3[] profile, Matrix4x4[] path, bool closed)
    {
        Mesh mesh = new Mesh();

        int numVerts = path.Length * profile.Length;
        int numTris;

        if (closed)
            numTris = 2 * path.Length * profile.Length;
        else
            numTris = 2 * (path.Length - 1) * profile.Length;


        Vector3[] vertices = new Vector3[numVerts];
        int[] tris = new int[numTris * 3];

        for (int i = 0; i < path.Length; i++)
        {
            for (int j = 0; j < profile.Length; j++)
            {
                Vector3 v = path[i].MultiplyPoint(profile[j]);
                vertices[i * profile.Length + j] = v;

                if (closed || i < path.Length - 1)
                {

                    tris[6 * (i * profile.Length + j)] = (j + i * profile.Length);
                    tris[6 * (i * profile.Length + j) + 1] = ((j + 1) % profile.Length + i * profile.Length);
                    tris[6 * (i * profile.Length + j) + 2] = ((j + 1) % profile.Length + ((i + 1) % path.Length) * profile.Length);
                    tris[6 * (i * profile.Length + j) + 3] = (j + i * profile.Length);
                    tris[6 * (i * profile.Length + j) + 4] = ((j + 1) % profile.Length + ((i + 1) % path.Length) * profile.Length);
                    tris[6 * (i * profile.Length + j) + 5] = (j + ((i + 1) % path.Length) * profile.Length);
                }
            }
        }

        mesh.vertices = vertices;

        mesh.triangles = tris;

        mesh.RecalculateNormals();

        return mesh;
    }

    public static Matrix4x4[] MakeCirclePath(float radius, int density)
    {
        Matrix4x4[] path = new Matrix4x4[density];
        for (int i = 0; i < density; i++)
        {
            float angle = (360.0f * i) / density;
            path[i] = Matrix4x4.Rotate(Quaternion.Euler(0, -angle, 0)) * Matrix4x4.Translate(new Vector3(radius, 0, 0));
        }
        return path;
    }

    public static Vector3[] MakeCircleProfile(float radius, int density)
    {
        Vector3[] profile = new Vector3[density];
        for (int i = 0; i < density; i++)
        {
            float angle = (2.0f * Mathf.PI * i) / density;
            profile[i] = new Vector3(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle), 0);
        }
        return profile;
    }

}