fdkaac_dep = dependency('fdk-aac', allow_fallback: true, required : get_option('fdkaac'), include_type: 'system')

fdkaac_sources = [
  'gstfdkaac.c',
  'gstfdkaacenc.c',
  'gstfdkaacdec.c',
  'gstfdkaacplugin.c',
]

fdkaac_headers = [
  'gstfdkaacdec.h',
  'gstfdkaacenc.h',
  'gstfdkaac.h',
]

doc_sources = []
foreach s: fdkaac_sources + fdkaac_headers
  doc_sources += meson.current_source_dir() / s
endforeach

plugin_sources += {
  'fdkaac': pathsep.join(doc_sources)
}

if fdkaac_dep.found()
  fdkaac_defines = []

  # Enable 7.1 support
  if fdkaac_dep.version().version_compare('>=0.1.4')
    fdkaac_defines += ['-DHAVE_FDK_AAC_0_1_4']
  endif

  # API v2
  if fdkaac_dep.version().version_compare('>=2.0.0')
    fdkaac_defines += ['-DHAVE_FDK_AAC_2_0_0']
  endif

  gstfdkaac = library('gstfdkaac',
    fdkaac_sources,
    c_args : gst_plugins_bad_args + fdkaac_defines,
    include_directories : [configinc],
    dependencies : [gstaudio_dep, gstpbutils_dep, fdkaac_dep],
    install : true,
    install_dir : plugins_install_dir,
  )
  plugins += [gstfdkaac]
endif
