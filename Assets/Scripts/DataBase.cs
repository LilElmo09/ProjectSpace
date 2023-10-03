using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DataBase : MonoBehaviour
{
    public Text displayText;

    private void Start()
    {
        // Muestra el cuadro de diálogo de selección de archivos
        string filePath = GetFilePath();

        // Verifica si se seleccionó un archivo
        if (!string.IsNullOrEmpty(filePath))
        {
            try
            {
                // Intenta leer el contenido del archivo de texto
                string fileContent = File.ReadAllText(filePath);

                // Verifica si el contenido no está vacío
                if (!string.IsNullOrEmpty(fileContent))
                {
                    // Muestra el contenido en la interfaz de usuario
                    displayText.text = fileContent;
                }
                else
                {
                    Debug.LogWarning("El archivo de texto está vacío.");
                }
            }
            catch (IOException ex)
            {
                Debug.LogError("Error al leer el archivo de texto: " + ex.Message);
            }
        }
        else
        {
            Debug.LogWarning("No se seleccionó ningún archivo.");
        }
    }

    private string GetFilePath()
    {
        string filePath = string.Empty;

        // Muestra el cuadro de diálogo de selección de archivos del sistema operativo
        string file = UnityEditor.EditorUtility.OpenFilePanel("Seleccionar archivo de texto", "", "txt");

        // Verifica si se seleccionó un archivo
        if (!string.IsNullOrEmpty(file))
        {
            filePath = file;
        }

        return filePath;
    }
}