aconv_sources = [
  'gstaudioconvert.c',
  'plugin.c'
  ]

aconv_headers = [
  'gstaudioconvert.h',
]

doc_sources = []
foreach s: aconv_sources + aconv_headers
  doc_sources += meson.current_source_dir() / s
endforeach

plugin_sources += {
  'audioconvert': pathsep.join(doc_sources)
}

if get_option('audioconvert').disabled()
  subdir_done()
endif

gstaudioconvert = library('gstaudioconvert',
  aconv_sources,
  c_args : gst_plugins_base_args,
  include_directories: [configinc, libsinc],
  dependencies : [audio_dep, gst_base_dep],
  install : true,
  install_dir : plugins_install_dir,
)
plugins += [gstaudioconvert]
