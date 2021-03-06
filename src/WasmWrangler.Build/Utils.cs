﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace WasmWrangler.Build
{
    public static class Utils
    {
        public static List<string> GetReferencedAssemblies(string sdkPath, string assemblyPath)
        {
            Assembly assembly;

            try
            {
                assembly = Assembly.LoadFile(assemblyPath);
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"Failed to load assembly \"{assemblyPath}\".");
            }

            var assemblyDirectory = Path.GetDirectoryName(assemblyPath);

            if (assemblyDirectory == null)
                throw new InvalidOperationException($"Assembly directory is null.");

            var referencedAssemblies = new List<string>();

            ItereateReferenceAssemblies(sdkPath, assembly, assemblyDirectory, referencedAssemblies);

            referencedAssemblies.Sort();

            return referencedAssemblies;

            static void ItereateReferenceAssemblies(string sdkPath, Assembly assembly, string assemblyDirectory, List<string> referencedAssemblies)
            {
                foreach (var referencedAssemblyName in assembly.GetReferencedAssemblies())
                {
                    if (referencedAssemblyName.Name == null)
                        continue;

                    var referencedAssemblyFileName = referencedAssemblyName.Name + ".dll";

                    if (referencedAssemblies.Contains(referencedAssemblyFileName))
                        continue;

                    Assembly? referencedAssembly = null;

                    var localAssemblyPath = Path.Combine(assemblyDirectory, referencedAssemblyFileName);
                    if (File.Exists(localAssemblyPath))
                    {
                        referencedAssembly = Assembly.LoadFile(localAssemblyPath);
                    }
                    else
                    {
                        var wasmBclPath = Path.Combine(sdkPath, "wasm-bcl", "wasm");

                        var wasmAssemblyPath = Path.Combine(wasmBclPath, referencedAssemblyFileName);
                        if (File.Exists(wasmAssemblyPath))
                        {
                            referencedAssembly = Assembly.LoadFile(wasmAssemblyPath);
                        }
                        else
                        {
                            var wasmFacadePath = Path.Combine(wasmBclPath, "Facades", referencedAssemblyFileName);
                            if (File.Exists(wasmFacadePath))
                            {
                                referencedAssembly = Assembly.LoadFile(wasmFacadePath);
                            }
                        }
                    }

                    if (referencedAssembly == null)
                        throw new InvalidOperationException($"Unable to load assembly \"{referencedAssemblyName.Name}\".");

                    referencedAssemblies.Add(referencedAssemblyFileName);

                    ItereateReferenceAssemblies(sdkPath, referencedAssembly, assemblyDirectory, referencedAssemblies);
                }
            }
        }

        public static void CopyFileIfNewer(string source, string destination)
        {
            // TODO: Really implement CopyFileIfNewer
            File.Copy(source, destination, true);
        }
    }
}
